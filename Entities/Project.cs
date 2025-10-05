using Task_Managment.SharedModels.Entities;
using static Task_Managment.Enums.EnumExtensions;

namespace Task_Managment.Entities
{
    public class Project : BaseEnity
    {
        public string? Name { get; set; } 
        public string? Description { get; set; } 
        public ProjectStatus? Status { get; set; }
        public bool isDeleted { get; set; } = false;
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }

   
}
