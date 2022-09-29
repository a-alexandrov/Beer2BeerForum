using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer2Beer.Data.Migrations
{
    public partial class TestSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "CommentsCount", "Content", "CreatedOn", "IsDeleted", "PostDislikes", "PostLikes", "Title", "UserID" },
                values: new object[,]
                {
                    { 1, 2, "I beg to be free", new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(7668), false, 2, 0, "End Forum Slavery", 3 },
                    { 2, 2, "Have you tried it", new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(9719), false, 1, 1, "Carlsberg Beer Opinions", 1 },
                    { 3, 2, "Dont laught too hard", new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(9836), false, 0, 2, "The best beer meme", 2 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "CreatedOn", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(4248), false, "ShitPost" },
                    { 2, new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(4725), false, "General" },
                    { 3, new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(4758), false, "Admin Topics" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 711, DateTimeKind.Local).AddTicks(9299));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 716, DateTimeKind.Local).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 716, DateTimeKind.Local).AddTicks(3004));

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "Content", "CreatedOn", "IsDeleted", "PostID", "UserID" },
                values: new object[,]
                {
                    { 1, "No", new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(5466), false, 1, 1 },
                    { 2, "I think things are just fine now", new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(6560), false, 1, 2 },
                    { 3, "That beer is great", new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(6686), false, 2, 2 },
                    { 4, "Slaves dont drink beers", new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(6692), false, 2, 3 },
                    { 5, "Quality meme", new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(6698), false, 3, 1 },
                    { 6, "I would laugh but slaves never laught", new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(6703), false, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "TagPosts",
                columns: new[] { "ID", "PostID", "TagID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 3, 2, 1 },
                    { 2, 1, 2 },
                    { 4, 2, 2 },
                    { 5, 3, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TagPosts",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 28, 11, 55, 41, 79, DateTimeKind.Local).AddTicks(3666));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 28, 11, 55, 41, 73, DateTimeKind.Local).AddTicks(7168));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 28, 11, 55, 41, 77, DateTimeKind.Local).AddTicks(7614));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 28, 11, 55, 41, 77, DateTimeKind.Local).AddTicks(7757));
        }
    }
}
