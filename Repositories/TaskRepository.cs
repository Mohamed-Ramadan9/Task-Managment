using Microsoft.EntityFrameworkCore;
using Task_Managment.Context;
using Task_Managment.Interfaces.Repositories;

namespace Task_Managment.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementContext _context;

        public TaskRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task_Managment.Entities.Task?>> GetAllAsync() =>
            await _context.Tasks
                .Include(t => t.Project)
                .AsNoTracking()
                .ToListAsync();

        public async Task<Task_Managment.Entities.Task?> GetByIdAsync(int id) =>
            await _context.Tasks
                .Include(t => t.Project)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<IEnumerable<Task_Managment.Entities.Task?>> GetTasksByProjectId(int projectid)
        {
          return await _context.Tasks.Include(t => t.Project).AsNoTracking().Where(t => t.ProjectId == projectid).ToListAsync();
        }
        public async Task AddAsync(Task_Managment.Entities.Task? task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync(); 
        }

 
        public async Task UpdateAsync(Task_Managment.Entities.Task? task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync(); 
        }

   
        public async Task DeleteAsync(Task_Managment.Entities.Task? task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(); 
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
