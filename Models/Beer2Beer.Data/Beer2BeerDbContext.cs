using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Beer2Beer.Data
{
    internal class Beer2BeerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //We should have same server name and remove magic string.
            //https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings
            optionsBuilder.UseSqlServer(@"Server=.;Database=Beer2Beer;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        DbSet<Admin> Admins { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<TagPost> TagPosts { get; set; }
        DbSet<User> Users { get; set; }
    }
}
