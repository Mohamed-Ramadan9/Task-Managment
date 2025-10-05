using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Task_Managment.DTOs.Task.Create;
using Task_Managment.DTOs.Task.Update;
using Task_Managment.Interfaces.Services;
using Task_Managment.Services;

namespace Task_Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        private readonly IValidator<TaskCreateDTO> _createValidator;
        private readonly IValidator<TaskUpdateDTO> _updateValidator;
        private readonly ILogger<TasksController> _logger;

        public TasksController(
            ITaskService taskService,
            IMapper mapper,
            IValidator<TaskCreateDTO> createValidator,
            IValidator<TaskUpdateDTO> updateValidator,
            ILogger<TasksController> logger)
        {
            _taskService = taskService;
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
                var tasks = await _taskService.GetAllAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all tasks");
                return StatusCode(500, "An error occurred while retrieving tasks.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var task = await _taskService.GetByIdAsync(id);
                if (task == null)
                    return NotFound($"Task with ID {id} not found.");

                return Ok(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching task with ID {id}");
                return StatusCode(500, "An error occurred while retrieving the task.");
            }
        }
        [HttpGet("by-project/{projectId}")]
        public async Task<IActionResult> GetTasksByProjectId(int projectId)
        {
            try
            {
                var tasks = await _taskService.GetByProjectIdAsync(projectId);

                if (tasks == null || !tasks.Any())
                    return NotFound(new { message = $"No tasks found for Project ID {projectId}." });

                return Ok(tasks);
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


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskCreateDTO dto)
        {
            var validation = await _createValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                await _taskService.CreateAsync(dto);
                return Ok("Task created successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating task");
                return StatusCode(500, "An error occurred while creating the task.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskUpdateDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID in route and DTO must match.");

            var validation = await _updateValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                await _taskService.UpdateAsync(dto);
          
                return Ok("Task updated successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating task with ID {id}");
                return StatusCode(500, "An error occurred while updating the task.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _taskService.DeleteAsync(id);
                if (!deleted)
                    return NotFound($"Task with ID {id} not found.");

                return Ok("Task deleted successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting task with ID {id}");
                return StatusCode(500, "An error occurred while deleting the task.");
            }
        }
    }
}