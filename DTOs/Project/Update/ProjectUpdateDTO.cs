using Task_Managment.DTOs.Task.Update;
using static Task_Managment.Enums.EnumExtensions;

namespace Task_Managment.DTOs.Project.Update
{
    public class ProjectUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ProjectStatus? Status { get; set; }
        public DateTime? StartDate { set; get; }
        public DateTime? EndDate { set; get; }
        public bool isDeleted { get; set; } = false;
        public List<TaskUpdateDTO>? Tasks { get; set; } = new();
    }
}
