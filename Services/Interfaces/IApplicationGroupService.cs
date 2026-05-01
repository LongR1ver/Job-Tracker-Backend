using Job_Application_Web.DTOs.ApplicationGroups;

namespace Job_Application_Web.Services.Interfaces
{
    public interface IApplicationGroupService
    {
        Task<List<ApplicationGroupDto>> GetAllAsync();
        Task<ApplicationGroupDto?> GetByIdAsync(Guid id);
        Task<ApplicationGroupDto> CreateAsync(CreateApplicationGroupDto dto);
        Task<ApplicationGroupDto?> UpdateAsync(Guid id, UpdateApplicationGroupDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
