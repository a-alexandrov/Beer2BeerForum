﻿// <auto-generated />
using System;
using Beer2Beer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Beer2Beer.Data.Migrations
{
    [DbContext(typeof(Beer2BeerDbContext))]
    [Migration("20221004134439_AddPhoneColumnToUserTable")]
    partial class AddPhoneColumnToUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Beer2Beer.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Content = "No",
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(8677),
                            IsDeleted = false,
                            PostID = 1,
                            UserID = 1
                        },
                        new
                        {
                            ID = 2,
                            Content = "I think things are just fine now",
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(9266),
                            IsDeleted = false,
                            PostID = 1,
                            UserID = 2
                        },
                        new
                        {
                            ID = 3,
                            Content = "That beer is great",
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(9297),
                            IsDeleted = false,
                            PostID = 2,
                            UserID = 2
                        },
                        new
                        {
                            ID = 4,
                            Content = "Slaves dont drink beers",
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(9301),
                            IsDeleted = false,
                            PostID = 2,
                            UserID = 3
                        },
                        new
                        {
                            ID = 5,
                            Content = "Quality meme",
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(9304),
                            IsDeleted = false,
                            PostID = 3,
                            UserID = 1
                        },
                        new
                        {
                            ID = 6,
                            Content = "I would laugh but slaves never laught",
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(9307),
                            IsDeleted = false,
                            PostID = 3,
                            UserID = 3
                        });
                });

            modelBuilder.Entity("Beer2Beer.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommentsCount")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(8192);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PostDislikes")
                        .HasColumnType("int");

                    b.Property<int>("PostLikes")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CommentsCount = 2,
                            Content = "I beg to be free",
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(9644),
                            IsDeleted = false,
                            PostDislikes = 2,
                            PostLikes = 0,
                            Title = "End Forum Slavery",
                            UserID = 3
                        },
                        new
                        {
                            ID = 2,
                            CommentsCount = 2,
                            Content = "Have you tried it",
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 396, DateTimeKind.Local).AddTicks(473),
                            IsDeleted = false,
                            PostDislikes = 1,
                            PostLikes = 1,
                            Title = "Carlsberg Beer Opinions",
                            UserID = 1
                        },
                        new
                        {
                            ID = 3,
                            CommentsCount = 2,
                            Content = "Dont laught too hard",
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 396, DateTimeKind.Local).AddTicks(528),
                            IsDeleted = false,
                            PostDislikes = 0,
                            PostLikes = 2,
                            Title = "The best beer meme",
                            UserID = 2
                        });
                });

            modelBuilder.Entity("Beer2Beer.Models.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(8087),
                            IsDeleted = false,
                            Name = "ShitPost"
                        },
                        new
                        {
                            ID = 2,
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(8321),
                            IsDeleted = false,
                            Name = "General"
                        },
                        new
                        {
                            ID = 3,
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(8335),
                            IsDeleted = false,
                            Name = "Admin Topics"
                        });
                });

            modelBuilder.Entity("Beer2Beer.Models.TagPost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.Property<int>("TagID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PostID");

                    b.HasIndex("TagID");

                    b.ToTable("TagPosts");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            PostID = 1,
                            TagID = 1
                        },
                        new
                        {
                            ID = 2,
                            PostID = 1,
                            TagID = 2
                        },
                        new
                        {
                            ID = 3,
                            PostID = 2,
                            TagID = 1
                        },
                        new
                        {
                            ID = 4,
                            PostID = 2,
                            TagID = 2
                        },
                        new
                        {
                            ID = 5,
                            PostID = 3,
                            TagID = 3
                        });
                });

            modelBuilder.Entity("Beer2Beer.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 392, DateTimeKind.Local).AddTicks(1607),
                            Email = "beerKing@abv.bg",
                            FirstName = "Forum",
                            IsAdmin = true,
                            IsBlocked = false,
                            IsDeleted = false,
                            LastName = "King",
                            PasswordHash = "THeKingIsHere",
                            Username = "BeerKing"
                        },
                        new
                        {
                            ID = 4,
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 394, DateTimeKind.Local).AddTicks(6398),
                            Email = "beerEmperor@rome.com",
                            FirstName = "Emperor",
                            IsAdmin = true,
                            IsBlocked = false,
                            IsDeleted = false,
                            LastName = "Beer",
                            PasswordHash = "YourEMperorHasReturnted",
                            Username = "BeerEmperor"
                        },
                        new
                        {
                            ID = 5,
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 394, DateTimeKind.Local).AddTicks(6510),
                            Email = "beerGod@heaven.universe",
                            FirstName = "God",
                            IsAdmin = true,
                            IsBlocked = false,
                            IsDeleted = false,
                            LastName = "Almighty",
                            PasswordHash = "BowToYourGod",
                            Username = "BeerGod"
                        },
                        new
                        {
                            ID = 2,
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 394, DateTimeKind.Local).AddTicks(6517),
                            Email = "beerPeasent@mail.bg",
                            FirstName = "Beer",
                            IsAdmin = false,
                            IsBlocked = false,
                            IsDeleted = false,
                            LastName = "Peasunt",
                            PasswordHash = "ThePeasentIsHere",
                            Username = "BeerPeasunt"
                        },
                        new
                        {
                            ID = 3,
                            CreatedOn = new DateTime(2022, 10, 4, 16, 44, 39, 394, DateTimeKind.Local).AddTicks(6521),
                            Email = "beerSlave@mail.bg",
                            FirstName = "Beer",
                            IsAdmin = false,
                            IsBlocked = false,
                            IsDeleted = false,
                            LastName = "Slave",
                            PasswordHash = "TheSlaveIsHere",
                            Username = "BeerSlave"
                        });
                });

            modelBuilder.Entity("Beer2Beer.Models.Comment", b =>
                {
                    b.HasOne("Beer2Beer.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Beer2Beer.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Beer2Beer.Models.Post", b =>
                {
                    b.HasOne("Beer2Beer.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Beer2Beer.Models.TagPost", b =>
                {
                    b.HasOne("Beer2Beer.Models.Post", "Post")
                        .WithMany("TagPosts")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Beer2Beer.Models.Tag", "Tag")
                        .WithMany("TagPosts")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}