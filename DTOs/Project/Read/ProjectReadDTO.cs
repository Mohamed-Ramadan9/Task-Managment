using Task_Managment.DTOs.Task.Read;
using static Task_Managment.Enums.EnumExtensions;

namespace Task_Managment.DTOs.Project.Read
{
    public class ProjectReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ProjectStatus? Status { get; set; }
        public bool isDeleted { get; set; } = false;
        public List<TaskReadDTO> Tasks { get; set; } = new();
    }
}
