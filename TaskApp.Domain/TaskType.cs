namespace TaskApp.Domain
{
    public class TaskType : BaseDomain
    {
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
