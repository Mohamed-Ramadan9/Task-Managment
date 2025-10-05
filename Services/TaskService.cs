using Task_Managment.Interfaces.Repositories;
using Task_Managment.Entities;
using Task_Managment.Interfaces.Services;
using Task_Managment.DTOs.Task.Read;
using AutoMapper;
using Task_Managment.DTOs.Project.Read;
using Task_Managment.DTOs.Task.Create;
using Task_Managment.DTOs.Task.Update;

namespace Task_Managment.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepo;
        private readonly ILogger<TaskService> _logger;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepo, ILogger<TaskService> logger , IMapper mapper)
        {
            _taskRepo = taskRepo;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskReadDTO>> GetAllAsync()
        {
            try
            {
                
                var Tasks= await _taskRepo.GetAllAsync();
                return _mapper.Map<IEnumerable<TaskReadDTO>>(Tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all tasks");
                throw new ApplicationException("An error occurred while fetching tasks.", ex);
            }
        }

        public async Task<TaskReadDTO> GetByIdAsync(int id)
        {
            try
            {
                var Task = await _taskRepo.GetByIdAsync(id);
                return _mapper.Map<TaskReadDTO>(Task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching task with ID {id}");
                throw new ApplicationException("An error occurred while fetching the task.", ex);
            }
        }
        public async Task<IEnumerable<TaskReadDTO>> GetByProjectIdAsync(int projectId)
        {
           var tasks = await _taskRepo.GetTasksByProjectId(projectId);
            return _mapper.Map<IEnumerable<TaskReadDTO>>(tasks);
        }

        public async System.Threading.Tasks.Task CreateAsync(TaskCreateDTO taskdto)
        {
            try
            {
                var task = _mapper.Map<Task_Managment.Entities.Task>(taskdto);
                await _taskRepo.AddAsync(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding task");
                throw new ApplicationException("An error occurred while adding the task.", ex);
            }
        }

        public async System.Threading.Tasks.Task UpdateAsync(TaskUpdateDTO taskdto)
        {
            try
            {
                var task = _mapper.Map<Task_Managment.Entities.Task>(taskdto);
                await _taskRepo.UpdateAsync(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating task with ID {taskdto.Id}");
                throw new ApplicationException("An error occurred while updating the task.", ex);
            }
        }

        public async System.Threading.Tasks.Task<bool> DeleteAsync(int id)
        {
            try
            {

                var task = await _taskRepo.GetByIdAsync(id);

                if (task == null)
                {
                    _logger.LogError($"Task with ID {id} not found.");
                    return false;
                }

                await _taskRepo.DeleteAsync(task);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting Task with ID {id}");
                throw new ApplicationException("An error occurred while deleting the Task.", ex);
            }
        }

        
    }
}
