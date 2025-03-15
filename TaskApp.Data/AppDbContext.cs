using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TaskApp.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace TaskApp.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userRoleId = "a37852f4-db74-497d-9cdd-ced4e436c9ad";
            var adminRoleId = "c41bea78-f72f-4954-88b0-9d62bf9bea65";
            var roles = new List<IdentityRole<Guid>>
            {
                new IdentityRole<Guid>
                {
                    Id = Guid.Parse(userRoleId),
                    ConcurrencyStamp = userRoleId,
                    Name = "USER",
                    NormalizedName = "USER"
                },
                new IdentityRole<Guid>
                {
                    Id = Guid.Parse(adminRoleId),
                    ConcurrencyStamp = adminRoleId,
                    Name = "ADMIN",
                    NormalizedName = "ADMIN"
                }
            };
            builder.Entity<IdentityRole<Guid>>().HasData(roles);


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseDomain>()
                .Where(q => q.State == EntityState.Modified || q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                entry.Entity.ModifiedAt = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
