using Beer2Beer.Data.Contracts;
using Beer2Beer.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Beer2Beer.Data
{
    public class Beer2BeerDbContext : DbContext, IBeer2BeerDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //We should have same server name and remove magic string.
            //https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings
            optionsBuilder.UseSqlServer(@"Server=.;Database=Beer2Beer;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne<Admin>()
                .WithOne(a => a.User)
              .HasForeignKey<Admin>(a => a.ID);

            modelBuilder.Entity<User>().HasData(
                new User { ID = 1, IsDeleted = false, IsAdmin = true, Email = "beerKing@abv.bg", PasswordHash = "THeKingIsHere", Username = "BeerKing", FirstName = "Forum", LastName = "King" },
                new User { ID = 4, IsDeleted = false, IsAdmin = true, Email = "beerEmperor@rome.com", PasswordHash = "YourEMperorHasReturnted", Username = "BeerEmperor", FirstName = "Emperor", LastName = "Beer" },
                new User { ID = 5, IsDeleted = false, IsAdmin = true, Email = "beerGod@heaven.universe", PasswordHash = "BowToYourGod", Username = "BeerGod", FirstName = "God", LastName = "Almighty" },
                new User { ID = 2, IsDeleted = false, IsAdmin = false, Email = "beerPeasent@mail.bg", PasswordHash = "ThePeasentIsHere", Username = "BeerPeasunt", FirstName = "Beer", LastName = "Peasunt" },
                new User { ID = 3, IsDeleted = false, IsAdmin = false, Email = "beerSlave@mail.bg", PasswordHash = "TheSlaveIsHere", Username = "BeerSlave", FirstName = "Beer", LastName = "Slave" });

            modelBuilder.Entity<Admin>().HasData(
                new Admin { ID = 1, PhoneNumber = "0888888888", UserID= 1},
                new Admin { ID = 2, PhoneNumber = "029212100", UserID = 2},
                new Admin { ID = 3, PhoneNumber = null, UserID= 3});

            modelBuilder.Entity<TagPost>().HasData(
                new TagPost { ID = 1 , PostID = 1, TagID = 1},
                new TagPost { ID = 2, PostID = 1, TagID = 2},
                new TagPost { ID = 3, PostID = 2, TagID = 1},
                new TagPost { ID = 4 , PostID= 2, TagID = 2},
                new TagPost { ID = 5, PostID = 3, TagID = 3}
                );

            modelBuilder.Entity<Tag>().HasData(
                new Tag { ID = 1, Name = "ShitPost"},
                new Tag { ID = 2, Name = "General"},
                new Tag { ID = 3, Name = "Admin Topics"}
                );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { ID = 1, UserID = 1, PostID = 1, Content = "No"},
                new Comment { ID = 2, UserID = 2, PostID = 1, Content = "I think things are just fine now"},
                new Comment { ID = 3, UserID = 2, PostID = 2, Content = "That beer is great"},
                new Comment { ID = 4, UserID = 3, PostID = 2, Content = "Slaves dont drink beers"},
                new Comment { ID = 5, UserID = 1, PostID = 3, Content = "Quality meme"},
                new Comment { ID = 6, UserID = 3, PostID = 3, Content = "I would laugh but slaves never laught"}
                );

            modelBuilder.Entity<Post>().HasData(
                new Post { ID = 1 , UserID = 3, Title = "End Forum Slavery", Content = "I beg to be free", PostDislikes= 2, PostLikes = 0, CommentsCount = 2},
                new Post { ID = 2 , UserID = 1, Title = "Carlsberg Beer Opinions", Content = "Have you tried it", PostDislikes= 1, PostLikes = 1, CommentsCount = 2 },
                new Post { ID = 3 , UserID = 2, Title = "The best beer meme", Content = "Dont laught too hard", PostDislikes= 0, PostLikes = 2, CommentsCount = 2 }
                );

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
