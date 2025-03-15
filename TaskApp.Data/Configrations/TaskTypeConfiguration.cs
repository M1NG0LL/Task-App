using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskApp.Domain;

namespace TaskApp.Data.Configrations
{
    public class TaskTypeConfiguration : IEntityTypeConfiguration<TaskType>
    {
        public void Configure(EntityTypeBuilder<TaskType> builder)
        {
            builder.Property(p => p.Title).IsRequired();

            builder
           .HasOne(t => t.User)
           .WithMany(u => u.TaskTypes)
           .HasForeignKey(t => t.UserId)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
