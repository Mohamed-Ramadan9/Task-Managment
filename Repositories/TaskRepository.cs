using Microsoft.EntityFrameworkCore;
using Task_Managment.Context;
using Task_Managment.Entities;
using Task_Managment.Interfaces.Repositories;
using Task_Managment.SharedModels.Response;

namespace Task_Managment.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementContext _context;

        public TaskRepository(TaskManagementContext context)
        {
            _context = context;
        }


        public async Task<PagedResult<Task_Managment.Entities.Task>> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.Tasks
                .Include(t => t.Project)
                .AsNoTracking();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(t => t.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Task_Managment.Entities.Task>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }


        public async Task<Task_Managment.Entities.Task?> GetByIdAsync(int id) =>
            await _context.Tasks
                .Include(t => t.Project)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<IEnumerable<Task_Managment.Entities.Task?>> GetTasksByProjectId(int projectid)
        {
          return await _context.Tasks.Include(t => t.Project).AsNoTracking().Where(t => t.ProjectId == projectid).ToListAsync();
        }
        public async System.Threading.Tasks.Task AddAsync(Task_Managment.Entities.Task? task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync(); 
        }

 
        public async System.Threading.Tasks.Task UpdateAsync(Task_Managment.Entities.Task? task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync(); 
        }

   
        public async System.Threading.Tasks.Task DeleteAsync(Task_Managment.Entities.Task? task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(); 
        }

        public async System.Threading.Tasks.Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
