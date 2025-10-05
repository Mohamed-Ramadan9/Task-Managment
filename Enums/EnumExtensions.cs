namespace Task_Managment.Enums
{
    public static class EnumExtensions
    {
        public enum TaskStatus
        {
            ToDo,             // Task created but not started
            InProgress,       // Work has begun
            InReview,         // Awaiting review, testing, or approval
            Completed,        // Fully done
            OnHold,          // Temporarily stopped by a dependency or issue
            Cancelled         // Abandoned or deemed unnecessary
        }
        public enum ProjectStatus
        {
            NotStarted,      // Just created — planning not started yet
            InProgress,      // Work is ongoing — tasks are being completed
            OnHold,          // Temporarily paused
            Completed,       // All tasks done, reviewed, and accepted
            Cancelled,       // Stopped before completion
            Archived         // Moved out of active tracking for history/reference
        }
    }
}
