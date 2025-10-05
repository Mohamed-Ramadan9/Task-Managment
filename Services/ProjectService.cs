using System.Net.WebSockets;
using AutoMapper;
using Task_Managment.DTOs.Project.Create;
using Task_Managment.DTOs.Project.Read;
using Task_Managment.DTOs.Project.Update;
using Task_Managment.Entities;
using Task_Managment.Interfaces.Repositories;
using Task_Managment.Interfaces.Services;

namespace Task_Managment.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;
        private readonly ILogger<ProjectService> _logger;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepo, ILogger<ProjectService> logger , IMapper mapper)
        {
            _projectRepo = projectRepo;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectReadDTO>> GetAllAsync()
        {
            try
            {
                var projects = await _projectRepo.GetAllAsync();
                return _mapper.Map<IEnumerable<ProjectReadDTO>>(projects);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all projects");
                throw new ApplicationException("An error occurred while fetching projects.", ex);
            }
        }

        public async Task<ProjectReadDTO?> GetByIdAsync(int id)
        {
            try
            {
                var project = await _projectRepo.GetByIdAsync(id);
                return _mapper.Map<ProjectReadDTO>(project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching project with ID {id}");
                throw new ApplicationException("An error occurred while fetching the project.", ex);
            }
        }

        public async System.Threading.Tasks.Task CreateAsync(ProjectCreateDTO projectDto)
        {
            try
            {
                var project = _mapper.Map<Project>(projectDto);
                await _projectRepo.AddAsync(project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding project");
                throw new ApplicationException("An error occurred while adding the project.", ex);
            }
        }

        public async System.Threading.Tasks.Task UpdateAsync(ProjectUpdateDTO projectDto)
        {
            try
            {
                var project = _mapper.Map<Project>(projectDto);
              await  _projectRepo.UpdateAsync(project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating project with ID {projectDto.Id}");
                throw new ApplicationException("An error occurred while updating the project.", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
              
                var project = await _projectRepo.GetByIdAsync(id);

                if (project == null)
                {
                    _logger.LogError($"Project with ID {id} not found.");
                    return false;
                }

                await _projectRepo.DeleteAsync(project); 
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting project with ID {id}");
                throw new ApplicationException("An error occurred while deleting the project.", ex);
            }
        }

        public async Task<bool> SoftDeleteAsync(int projectId)
        {
            try
            {
                return await _projectRepo.SoftDeleteAsync(projectId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error soft deleting project with ID {projectId}");
                throw new ApplicationException("Failed to soft delete project.", ex);
            }
        }

    }
}
