namespace Task_Managment.DTOs.Task.Update
{
    public class TaskUpdateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public int aproximateFinishTime { get; set; }
        public Task_Managment.Enums.EnumExtensions.TaskStatus status { get; set; }
        public int ProjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
