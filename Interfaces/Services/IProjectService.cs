using Task_Managment.DTOs.Project.Create;
using Task_Managment.DTOs.Project.Read;
using Task_Managment.DTOs.Project.Update;
using Task_Managment.DTOs.Task.Read;
using Task_Managment.SharedModels.Response;

namespace Task_Managment.Interfaces.Services
{
    public interface IProjectService
    {
        Task<PagedResult<ProjectReadDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<ProjectReadDTO> GetByIdAsync(int id);
        Task CreateAsync(ProjectCreateDTO projectDto);
        Task UpdateAsync(ProjectUpdateDTO projectDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> SoftDeleteAsync(int projectId);
    }
}
