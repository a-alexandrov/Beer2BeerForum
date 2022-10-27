using Beer2Beer.Data.Contracts;
using Beer2Beer.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;

namespace Beer2Beer.Data
{
    public class Beer2BeerDbContext : DbContext, IBeer2BeerDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Beer2Beer;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.SeedDb(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        DbSet<Comment> Comments { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<TagPost> TagPosts { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Like> Likes { get; set; }

        private void SeedDb(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    ID = 1,
                    IsDeleted = false,
                    IsAdmin = true,
                    Email = "beerKing@abv.bg",
                    PasswordHash = "THeKingIsHere",
                    Username = "BeerKing",
                    FirstName = "Forum",
                    LastName = "King",
                    AvatarImage = File.ReadAllBytes(@"..\Beer2Beer.Data\SeedData\blurryCat.jpg"),
                    ImageType = "jpg"
                },
                new User 
                { 
                    ID = 4, 
                    IsDeleted = false,
                    IsAdmin = true,
                    Email = "beerEmperor@rome.com",
                    PasswordHash = "YourEMperorHasReturnted",
                    Username = "BeerEmperor",
                    FirstName = "Emperor",
                    LastName = "Beer",
                    AvatarImage = File.ReadAllBytes(@"..\Beer2Beer.Data\SeedData\cats.jpg"),
                    ImageType = "jpg"
                },
                new User 
                { 
                    ID = 5,
                    IsDeleted = false,
                    IsAdmin = true,
                    Email = "beerGod@heaven.universe",
                    PasswordHash = "BowToYourGod",
                    Username = "BeerGod",
                    FirstName = "GodGod",
                    LastName = "Almighty",
                    PhoneNumber = "0883778833",
                    AvatarImage = File.ReadAllBytes(@"..\Beer2Beer.Data\SeedData\pikatchu.jpg"),
                    ImageType = "jpg"
                },
                new User 
                { 
                    ID = 2,
                    IsDeleted = false,
                    IsAdmin = false,
                    Email = "beerPeasent@mail.bg",
                    PasswordHash = "ThePeasentIsHere",
                    Username = "BeerPeasant",
                    FirstName = "Beer",
                    LastName = "Peasant",
                    AvatarImage = File.ReadAllBytes(@"..\Beer2Beer.Data\SeedData\shaggy.png"),
                    ImageType = "jpg"
                },
                new User 
                { 
                    ID = 3,
                    IsDeleted = false,
                    IsAdmin = false,
                    Email = "beerMan@mail.bg",
                    PasswordHash = "TheManIsHere",
                    Username = "BeerMan",
                    FirstName = "Beer",
                    LastName = "Maner",
                    AvatarImage = File.ReadAllBytes(@"..\Beer2Beer.Data\SeedData\startledDog.jpg"),
                    ImageType = "jpg"
                });

            
            modelBuilder.Entity<TagPost>().HasData(
                new TagPost { ID = 1, PostID = 1, TagID = 1 },
                new TagPost { ID = 2, PostID = 1, TagID = 2 },
                new TagPost { ID = 3, PostID = 2, TagID = 1 },
                new TagPost { ID = 4, PostID = 2, TagID = 2 },
                new TagPost { ID = 5, PostID = 3, TagID = 3 }
                );

            modelBuilder.Entity<Tag>().HasData(
                new Tag { ID = 1, Name = "ShiftedPost" },
                new Tag { ID = 2, Name = "General" },
                new Tag { ID = 3, Name = "Admin Topics" }
                );

            modelBuilder.Entity<Comment>().HasData(
                new Comment { ID = 1, UserID = 1, PostID = 1, Content = "No" },
                new Comment { ID = 2, UserID = 2, PostID = 1, Content = "I think things are just fine now" },
                new Comment { ID = 3, UserID = 2, PostID = 2, Content = "That beer is great" },
                new Comment { ID = 4, UserID = 3, PostID = 2, Content = "Who doesnt drink beers" },
                new Comment { ID = 5, UserID = 1, PostID = 3, Content = "Quality meme" },
                new Comment { ID = 6, UserID = 3, PostID = 3, Content = "I would laugh but beer drinkers never laught" }
                );

            modelBuilder.Entity<Post>().HasData(
                new Post 
                { 
                    ID = 1,
                    UserID = 3,
                    Title = "End Forum Beer drought throughout the forum ",
                    Content = "I beg to be free to drink beer. I beg to be beered",
                    PostDislikes = 2,
                    PostLikes = 0,
                    CommentsCount = 2 
                },
                new Post 
                { 
                    ID = 2,
                    UserID = 1,
                    Title = "Carlsberg Beer Opinions. Carlsberg Beer Opinions",
                    Content = "Have you tried it?Have you tried it!",
                    PostDislikes = 1,
                    PostLikes = 1,
                    CommentsCount = 2 
                },
                new Post 
                { 
                    ID = 3,
                    UserID = 2,
                    Title = "The best beer meme is The best beer meme",
                    Content = "Dont laught too hard, Dont fall too hard",
                    PostDislikes = 0,
                    PostLikes = 2,
                    CommentsCount = 2 
                });
        }
    }
}
