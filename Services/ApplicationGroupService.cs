using Job_Application_Web.Data;
using Job_Application_Web.DTOs.ApplicationGroups;
using Job_Application_Web.Models;
using Job_Application_Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Job_Application_Web.Services
{
    public class ApplicationGroupService : IApplicationGroupService
    {
        private readonly AppDbContext _context;

        public ApplicationGroupService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationGroupDto>> GetAllAsync()
        {
            return await _context.ApplicationGroups
                .Select(g => new ApplicationGroupDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description
                })
                .ToListAsync();
        }

        public async Task<ApplicationGroupDto?> GetByIdAsync(Guid id)
        {
            return await _context.ApplicationGroups
                .Where(g => g.Id == id)
                .Select(g => new ApplicationGroupDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ApplicationGroupDto> CreateAsync(CreateApplicationGroupDto dto)
        {
            var group = new ApplicationGroup
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.ApplicationGroups.Add(group);
            await _context.SaveChangesAsync();

            return new ApplicationGroupDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description
            };
        }

        public async Task<ApplicationGroupDto?> UpdateAsync(Guid id, UpdateApplicationGroupDto dto)
        {
            var group = await _context.ApplicationGroups.FindAsync(id);

            if (group == null)
                return null;

            if (dto.Name != null)
                group.Name = dto.Name;

            if (dto.Description != null)
                group.Description = dto.Description;

            if (dto.Color != null)
                group.Color = dto.Color;

            await _context.SaveChangesAsync();

            return new ApplicationGroupDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                Color = group.Color
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var group = await _context.ApplicationGroups.FindAsync(id);

            if (group == null)
                return false;

            _context.ApplicationGroups.Remove(group);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
