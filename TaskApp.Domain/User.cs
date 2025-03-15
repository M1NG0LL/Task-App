using Microsoft.AspNetCore.Identity;

namespace TaskApp.Domain
{
    public class User : IdentityUser<Guid>
    {
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();
        public List<TaskType> TaskTypes { get; set; } = new List<TaskType>();
    }
}
