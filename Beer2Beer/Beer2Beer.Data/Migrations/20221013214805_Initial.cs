using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer2Beer.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 32, nullable: false),
                    LastName = table.Column<string>(maxLength: 32, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    AvatarImage = table.Column<byte[]>(maxLength: 1048576, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.CheckConstraint("CK_User_FirstName", "LEN([FirstName]) >= 4");
                    table.CheckConstraint("CK_User_LastName", "LEN([LastName]) >= 4");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Content = table.Column<string>(maxLength: 8192, nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    PostLikes = table.Column<int>(nullable: false),
                    PostDislikes = table.Column<int>(nullable: false),
                    CommentsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                    table.CheckConstraint("CK_Post_Title", "LEN([Title]) >= 16");
                    table.CheckConstraint("CK_Post_Content", "LEN([Content]) >= 32");
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    PostID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TagPosts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagID = table.Column<int>(nullable: false),
                    PostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagPosts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TagPosts_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagPosts_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "CreatedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1012), false, "ShitPost" },
                    { 2, new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1202), false, "General" },
                    { 3, new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1215), false, "Admin Topics" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "AvatarImage", "CreatedOn", "Email", "FirstName", "IsAdmin", "IsBlocked", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 10, 14, 0, 48, 5, 700, DateTimeKind.Local).AddTicks(9848), "beerKing@abv.bg", "Forum", true, false, false, "King", "THeKingIsHere", null, "BeerKing" },
                    { 4, null, new DateTime(2022, 10, 14, 0, 48, 5, 703, DateTimeKind.Local).AddTicks(269), "beerEmperor@rome.com", "Emperor", true, false, false, "Beer", "YourEMperorHasReturnted", null, "BeerEmperor" },
                    { 5, null, new DateTime(2022, 10, 14, 0, 48, 5, 703, DateTimeKind.Local).AddTicks(348), "beerGod@heaven.universe", "GodGod", true, false, false, "Almighty", "BowToYourGod", "0883778833", "BeerGod" },
                    { 2, null, new DateTime(2022, 10, 14, 0, 48, 5, 703, DateTimeKind.Local).AddTicks(479), "beerPeasent@mail.bg", "Beer", false, false, false, "Peasunt", "ThePeasentIsHere", null, "BeerPeasunt" },
                    { 3, null, new DateTime(2022, 10, 14, 0, 48, 5, 703, DateTimeKind.Local).AddTicks(485), "beerSlave@mail.bg", "Beer", false, false, false, "Slave", "TheSlaveIsHere", null, "BeerSlave" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "CommentsCount", "Content", "CreatedOn", "IsDeleted", "PostDislikes", "PostLikes", "Title", "UserID" },
                values: new object[] { 2, 2, "Have you tried itHave you tried it", new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(2868), false, 1, 1, "Carlsberg Beer OpinionsCarlsberg Beer Opinions", 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "CommentsCount", "Content", "CreatedOn", "IsDeleted", "PostDislikes", "PostLikes", "Title", "UserID" },
                values: new object[] { 3, 2, "Dont laught too hardDont laught too hard", new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(2930), false, 0, 2, "The best beer memeThe best beer meme", 2 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "CommentsCount", "Content", "CreatedOn", "IsDeleted", "PostDislikes", "PostLikes", "Title", "UserID" },
                values: new object[] { 1, 2, "I beg to be freeI beg to be free", new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(2188), false, 2, 0, "End Forum SlaveryEnd Forum Slavery", 3 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "Content", "CreatedOn", "IsDeleted", "PostID", "UserID" },
                values: new object[,]
                {
                    { 3, "That beer is great", new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1874), false, 2, 2 },
                    { 4, "Slaves dont drink beers", new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1877), false, 2, 3 },
                    { 5, "Quality meme", new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1880), false, 3, 1 },
                    { 6, "I would laugh but slaves never laught", new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1883), false, 3, 3 },
                    { 1, "No", new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1476), false, 1, 1 },
                    { 2, "I think things are just fine now", new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1851), false, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "TagPosts",
                columns: new[] { "ID", "PostID", "TagID" },
                values: new object[,]
                {
                    { 3, 2, 1 },
                    { 4, 2, 2 },
                    { 5, 3, 3 },
                    { 1, 1, 1 },
                    { 2, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostID",
                table: "Comments",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserID",
                table: "Posts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TagPosts_PostID",
                table: "TagPosts",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_TagPosts_TagID",
                table: "TagPosts",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "TagPosts");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
