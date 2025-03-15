namespace TaskApp.Domain
{
    public class Tasks : BaseDomain
    {
        public Guid? TaskTypeId { get; set; }
        public TaskType? TaskType { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
