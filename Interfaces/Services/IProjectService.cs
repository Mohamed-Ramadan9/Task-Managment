using Task_Managment.DTOs.Project.Create;
using Task_Managment.DTOs.Project.Read;
using Task_Managment.DTOs.Project.Update;

namespace Task_Managment.Interfaces.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectReadDTO>> GetAllAsync();
        Task<ProjectReadDTO> GetByIdAsync(int id);
        Task CreateAsync(ProjectCreateDTO projectDto);
        Task UpdateAsync(ProjectUpdateDTO projectDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> SoftDeleteAsync(int projectId);
    }
}
