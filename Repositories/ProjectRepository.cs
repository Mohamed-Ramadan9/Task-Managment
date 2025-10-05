using System;
using Microsoft.EntityFrameworkCore;
using Task_Managment.Context;
using Task_Managment.Entities;
using Task_Managment.Interfaces.Repositories;

namespace Task_Managment.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskManagementContext _context;
        public ProjectRepository(TaskManagementContext context) => _context = context;

        public async Task<Project?> GetByIdAsync(int id) =>
            await _context.Projects.Include(p => p.Tasks).Where(p => p.isDeleted == false).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Project>> GetAllAsync() =>
            await _context.Projects.Include(p => p.Tasks).Where(p => p.isDeleted == false).ToListAsync();

        public async System.Threading.Tasks.Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(Project project)
        {
            _context.Projects.Remove(project);
            await SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task<bool> SoftDeleteAsync(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project == null)
            {
                throw new Exception("Project not found.");
           
            }

            project.isDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }



        public async System.Threading.Tasks.Task SaveChangesAsync() => await _context.SaveChangesAsync();

   
    }
}