using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Managment.DTOs.Project.Create;
using Task_Managment.DTOs.Project.Update;
using Task_Managment.Entities;
using Task_Managment.Interfaces.Services;
using Task_Managment.Services;

namespace Task_Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly IValidator<ProjectCreateDTO> _createValidator;
        private readonly IValidator<ProjectUpdateDTO> _updateValidator;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(
            IProjectService projectService,
            IMapper mapper,
            IValidator<ProjectCreateDTO> createValidator,
            IValidator<ProjectUpdateDTO> updateValidator,
            ILogger<ProjectsController> logger)
        {
            _projectService = projectService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var projects = await _projectService.GetAllAsync();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all projects");
                return StatusCode(500, "An error occurred while retrieving projects.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var project = await _projectService.GetByIdAsync(id);
                if (project == null)
                    return NotFound($"Project with ID {id} not found.");

                return Ok(project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching project with ID {id}");
                return StatusCode(500, "An error occurred while retrieving the project.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectCreateDTO dto)
        {
            var validation = await _createValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                await _projectService.CreateAsync(dto);
                return Ok("Project created successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating project");
                return StatusCode(500, "An error occurred while creating the project.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProjectUpdateDTO projectDto)
        {
            if (id != projectDto.Id)
                return BadRequest("ID in route and DTO must match.");

            var validation = await _updateValidator.ValidateAsync(projectDto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                await _projectService.UpdateAsync(projectDto);
                return Ok("Project updated successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating project with ID {id}");
                return StatusCode(500, "An error occurred while updating the project.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _projectService.DeleteAsync(id);
                if (!deleted)
                    return NotFound($"Project with ID {id} not found.");

                return Ok("Project deleted successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting project with ID {id}");
                return StatusCode(500, "An error occurred while deleting the project.");
            }
        }
        [HttpPatch("soft-delete/{id}")]
        public async Task<IActionResult> SoftDeleteProject(int id)
        {
            try
            {
                var result = await _projectService.SoftDeleteAsync(id);

                if (!result)
                    return NotFound(new { message = $"Project with ID {id} not found." });

                return Ok(new { message = $"Project with ID {id} was soft deleted successfully." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }
        }

    }
}
