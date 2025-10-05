using static Task_Managment.Enums.EnumExtensions;
namespace Task_Managment.DTOs.Task.Create
{
    public class TaskCreateDTO
    {
      
        public string Title { get; set; }
        public string? Description { get; set; }
        public Task_Managment.Enums.EnumExtensions.TaskStatus status { get; set; }
        public bool IsCompleted { get; set; }
        public int aproximateFinishTime { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime? StartDate { get; set;}

        public int ProjectId { get; set; }
    }
}
