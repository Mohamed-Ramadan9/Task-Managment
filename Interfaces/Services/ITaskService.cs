using Task_Managment.DTOs.Task.Create;
using Task_Managment.DTOs.Task.Read;
using Task_Managment.DTOs.Task.Update;
using Task_Managment.SharedModels.Response;

namespace Task_Managment.Interfaces.Services
{
    public interface ITaskService
    {
        Task<PagedResult<TaskReadDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<TaskReadDTO> GetByIdAsync(int id);
        Task<IEnumerable<TaskReadDTO>> GetByProjectIdAsync(int projectId);
        Task CreateAsync(TaskCreateDTO taskDto);
        Task UpdateAsync(TaskUpdateDTO taskDto);
        Task<bool> DeleteAsync(int id);
    }
}
