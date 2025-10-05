namespace Task_Managment.SharedModels.Entities
{
    public class BaseEnity
    {
        public int Id { set; get; }
        public DateTime? StartDate { set; get; } 
        public DateTime? EndDate { set; get; }
    }
}
