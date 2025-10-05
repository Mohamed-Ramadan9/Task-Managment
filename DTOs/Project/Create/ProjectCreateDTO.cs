using Task_Managment.DTOs.Task.Create;
using Task_Managment.DTOs.Task.Read;
using static Task_Managment.Enums.EnumExtensions;

namespace Task_Managment.DTOs.Project.Create
{
        public class ProjectCreateDTO
        {
            public string Name { get; set; }
            public string? Description { get; set; }
            public DateTime? StartDate { set; get; }
            public DateTime? EndDate { set; get; }
            public ProjectStatus? Status { get; set; }

        public List<TaskCreateDTO> Tasks { get; set; } = new();
    }
    
}
