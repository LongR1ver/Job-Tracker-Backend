using Job_Application_Web.Data;
using Job_Application_Web.DTOs.Auth;
using Job_Application_Web.Models;
using Job_Application_Web.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Job_Application_Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<AuthResponseDto?> RegisterAsync(RegisterDto dto)
        {
            var emailExists = await _context.Users
                .AnyAsync(u => u.Email == dto.Email);

            if (emailExists)
                return null;

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            _context.Users.Add(user);

            var refreshToken = CreateRefreshToken(user);

            _context.RefreshTokens.Add(refreshToken);

            await _context.SaveChangesAsync();

            return CreateAuthResponse(user, refreshToken);
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                dto.Password
            );

            if (result == PasswordVerificationResult.Failed)
                return null;

            var refreshToken = CreateRefreshToken(user);

            _context.RefreshTokens.Add(refreshToken);

            await _context.SaveChangesAsync();

            return CreateAuthResponse(user, refreshToken);
        }

        public async Task<AuthResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto dto)
        {
            var existingRefreshToken = await _context.RefreshTokens
                .Include(rt => rt.User)
                .FirstOrDefaultAsync(rt => rt.Token == dto.RefreshToken);

            if (existingRefreshToken == null)
                return null;

            if (existingRefreshToken.IsRevoked)
                return null;

            if (existingRefreshToken.ExpiresAt < DateTime.UtcNow)
                return null;

            existingRefreshToken.IsRevoked = true;
            existingRefreshToken.RevokedAt = DateTime.UtcNow;

            var user = existingRefreshToken.User;

            var newRefreshToken = CreateRefreshToken(user);

            _context.RefreshTokens.Add(newRefreshToken);

            await _context.SaveChangesAsync();

            return CreateAuthResponse(user, newRefreshToken);
        }

        public async Task<bool> LogoutAsync(LogoutRequestDto dto)
        {
            var refreshToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.Token == dto.RefreshToken);

            if (refreshToken == null)
                return false;

            if (refreshToken.IsRevoked)
                return true;

            refreshToken.IsRevoked = true;
            refreshToken.RevokedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        private string GenerateAccessToken(User user)
        {
            var jwtKey = _configuration["Jwt:Key"];
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];

            if (string.IsNullOrWhiteSpace(jwtKey))
                throw new InvalidOperationException("JWT key is missing.");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private RefreshToken CreateRefreshToken(User user)
        {
            return new RefreshToken
            {
                Token = GenerateRefreshToken(),
                UserId = user.Id,
                User = user,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                CreatedAt = DateTime.UtcNow
            };
        }

        private static string GenerateRefreshToken()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);

            return Convert.ToBase64String(randomBytes);
        }

        private AuthResponseDto CreateAuthResponse(User user, RefreshToken refreshToken)
        {
            return new AuthResponseDto
            {
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,

                AccessToken = GenerateAccessToken(user),
                AccessTokenExpiresAt = DateTime.UtcNow.AddMinutes(15),

                RefreshToken = refreshToken.Token,
                RefreshTokenExpiresAt = refreshToken.ExpiresAt
            };
        }
    }
}
