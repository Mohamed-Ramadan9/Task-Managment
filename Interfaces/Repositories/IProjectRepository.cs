using Task_Managment.Entities;
using Task_Managment.SharedModels.Response;

namespace Task_Managment.Interfaces.Repositories
{
    public interface IProjectRepository
    {
       
        
        Task<PagedResult<Project>> GetAllAsync(int pageNumber, int pageSize);
        Task<Project?> GetByIdAsync(int id);
        System.Threading.Tasks.Task AddAsync(Project project);
        System.Threading.Tasks.Task UpdateAsync(Project project);
        System.Threading.Tasks.Task DeleteAsync(Project project);
        System.Threading.Tasks.Task<bool> SoftDeleteAsync(int projectId);
        System.Threading.Tasks.Task SaveChangesAsync();
    }
}
