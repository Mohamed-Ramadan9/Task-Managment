using Task_Managment.DTOs.Task.Create;
using Task_Managment.DTOs.Task.Read;
using Task_Managment.DTOs.Task.Update;

namespace Task_Managment.Interfaces.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskReadDTO>> GetAllAsync();
        Task<TaskReadDTO> GetByIdAsync(int id);
        Task<IEnumerable<TaskReadDTO>> GetByProjectIdAsync(int projectId);
        Task CreateAsync(TaskCreateDTO taskDto);
        Task UpdateAsync(TaskUpdateDTO taskDto);
        Task<bool> DeleteAsync(int id);
    }
}
