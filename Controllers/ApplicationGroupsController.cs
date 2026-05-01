using Job_Application_Web.DTOs.ApplicationGroups;
using Job_Application_Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Job_Application_Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationGroupsController : ControllerBase
    {
        private readonly IApplicationGroupService _applicationGroupService;

        public ApplicationGroupsController(IApplicationGroupService applicationGroupService)
        {
            _applicationGroupService = applicationGroupService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ApplicationGroupDto>>> GetAll()
        {
            var groups = await _applicationGroupService.GetAllAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationGroupDto>> GetById(Guid id)
        {
            var group = await _applicationGroupService.GetByIdAsync(id);

            if (group == null)
                return NotFound();

            return Ok(group);
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationGroupDto>> Create(CreateApplicationGroupDto dto)
        {
            var createdGroup = await _applicationGroupService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdGroup.Id },
                createdGroup
            );
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ApplicationGroupDto>> Update(Guid id, UpdateApplicationGroupDto dto)
        {
            var updatedGroup = await _applicationGroupService.UpdateAsync(id, dto);

            if (updatedGroup == null)
                return NotFound(new { message = "Application group not found." });

            return Ok(updatedGroup);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _applicationGroupService.DeleteAsync(id);

            if (!result)
                return NotFound(new { message = "Application group not found." });

            return NoContent();
        }
    }
}
