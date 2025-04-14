using DotNetTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetTemplate.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<User>(buildAction =>
            {
                _ = buildAction.ToTable("users");

                _ = buildAction.HasKey(user => user.Id);
                _ = buildAction.Property(user => user.Id).ValueGeneratedOnAdd();
                _ = buildAction.Property(user => user.Name).HasMaxLength(100).IsUnicode(true).IsRequired(true);
                _ = buildAction.Property(user => user.AvatarUrl).IsRequired(false);
                _ = buildAction.Property(user => user.Email).IsRequired(true);
                _ = buildAction.HasIndex(x => x.Email);
                _ = buildAction.Property(user => user.HashPassword).IsRequired(true);
                _ = buildAction.Property(user => user.DateOfBirth).IsRequired(true);
                _ = buildAction.Property(user => user.RoleId).IsRequired(true);

                _ = buildAction.HasOne(user => user.Role).WithMany(role => role.Users);
            });

            _ = modelBuilder.Entity<Role>(buildAction =>
            {
                _ = buildAction.ToTable("roles");

                _ = buildAction.HasKey(role => role.Id);
                _ = buildAction.Property(role => role.Id).ValueGeneratedOnAdd();
                _ = buildAction.Property(role => role.RoleName).IsUnicode(true).IsRequired(true);
                _ = buildAction.Property(role => role.RoleDescription).HasMaxLength(200);
                _ = buildAction.HasMany(role => role.Users).WithOne(user => user.Role);

                var roles = new List<Role>()
                {
                    new() { Id = Guid.NewGuid(), RoleName = "Admin", RoleDescription = "Admin role" },
                    new() { Id = Guid.NewGuid(), RoleName = "User", RoleDescription = "User role" },
                };
                _ = buildAction.HasData(roles);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
