using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Snowman.Tourism.Domain;
using Snowman.Tourism.Domain.Identity;

namespace Snowman.Tourism.Repository
{
    public class TourismContext : IdentityDbContext<User, Role, int,
                                                    IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public TourismContext(DbContextOptions<TourismContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Spot> Spots { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<Category>()
                .Property(p => p.Id)
                .HasIdentityOptions(startValue: 5);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Description = "Park" },
                new Category { Id = 2, Description = "Museum" },
                new Category { Id = 3, Description = "Theater" },
                new Category { Id = 4, Description = "Monument" }
                ); ;
        }
    }
}
