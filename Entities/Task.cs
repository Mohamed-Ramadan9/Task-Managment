using Task_Managment.SharedModels.Entities;
using static Task_Managment.Enums.EnumExtensions;
namespace Task_Managment.Entities
{
    public class Task : BaseEnity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public int aproximateFinishTime { get; set; }   
        public Task_Managment.Enums.EnumExtensions.TaskStatus status {get ;set;}
        public int ProjectId { get; set; }
        public Project Project { get; set; } 
    }

  
}
