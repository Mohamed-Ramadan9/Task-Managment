using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task_Managment.Context;
using Task_Managment.Interfaces.Repositories;
using Task_Managment.Interfaces.Services;
using Task_Managment.Logger;
using Task_Managment.Repositories;
using Task_Managment.Services;
using AutoMapper;
using Task_Managment.Mapping;
using FluentValidation;
using Task_Managment.DTOs.Project.Create;
using Task_Managment.DTOs.Project.Update;
using Task_Managment.DTOs.Task.Create;
using Task_Managment.DTOs.Task.Update;
using Task_Managment.Validations.Project;
using Task_Managment.Validations.Task;

namespace Task_Managment.Injector
{
    public static class Injector
    {
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            InjectDbContext(services, configuration);
            InjectRepositories(services);
            InjectServices(services);
            InjectLogger(services);
            InjectAutoMapper(services);
            InjectValidators(services);
        }

        // -------------------- DbContext --------------------
        private static void InjectDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        // -------------------- Repositories --------------------
        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
        }

        // -------------------- Services --------------------
        private static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();
        }

        // -------------------- Logger --------------------
        private static void InjectLogger(IServiceCollection services)
        {
            services.AddSingleton(typeof(AppLogger<>));
        }

        // -------------------- AutoMapper --------------------  
        private static void InjectAutoMapper(IServiceCollection services)
        {
          
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(MappingProfile).Assembly));
        }

        // -------------------- Validators --------------------  
        private static void InjectValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<ProjectCreateDTO>, ProjectCreateDTOValidator>();
            services.AddScoped<IValidator<ProjectUpdateDTO>, ProjectUpdateDTOValidator>();
            services.AddScoped<IValidator<TaskCreateDTO>, TaskCreateDTOValidator>();
            services.AddScoped<IValidator<TaskUpdateDTO>, TaskUpdateDTOValidator>();
        }
    }
}


