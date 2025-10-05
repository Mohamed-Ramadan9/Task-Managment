using AutoMapper;
using Task_Managment.DTOs.Project.Create;
using Task_Managment.DTOs.Project.Read;
using Task_Managment.DTOs.Project.Update;
using Task_Managment.DTOs.Task.Create;
using Task_Managment.DTOs.Task.Read;
using Task_Managment.DTOs.Task.Update;
using Task_Managment.Entities;

namespace Task_Managment.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Project mappings
            CreateMap<Project, ProjectReadDTO>()
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));

            CreateMap<ProjectCreateDTO, Project>();
            CreateMap<ProjectUpdateDTO, Project>();

            // Task mappings
            CreateMap<Task_Managment.Entities.Task, TaskReadDTO>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name));
                //.ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.StartDate));

            CreateMap<TaskCreateDTO, Task_Managment.Entities.Task>();
            CreateMap<TaskUpdateDTO, Task_Managment.Entities.Task>();
        }
    }
}
