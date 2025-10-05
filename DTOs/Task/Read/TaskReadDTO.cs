namespace Task_Managment.DTOs.Task.Read
{
    public class TaskReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Task_Managment.Enums.EnumExtensions.TaskStatus status { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
