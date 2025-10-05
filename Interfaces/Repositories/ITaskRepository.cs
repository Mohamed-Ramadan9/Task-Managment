using Task_Managment.Entities;

namespace Task_Managment.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task<IEnumerable<Task_Managment.Entities.Task>> GetAllAsync();
        System.Threading.Tasks.Task<Task_Managment.Entities.Task> GetByIdAsync(int id);
        System.Threading.Tasks.Task<IEnumerable<Task_Managment.Entities.Task?>> GetTasksByProjectId(int projectid);
        System.Threading.Tasks.Task AddAsync(Task_Managment.Entities.Task task);
        System.Threading.Tasks.Task UpdateAsync(Task_Managment.Entities.Task task);
        System.Threading.Tasks.Task DeleteAsync(Task_Managment.Entities.Task task);
        System.Threading.Tasks. Task SaveChangesAsync();
    }
}
