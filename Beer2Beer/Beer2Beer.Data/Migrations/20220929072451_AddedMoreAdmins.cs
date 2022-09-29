using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer2Beer.Data.Migrations
{
    public partial class AddedMoreAdmins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 739, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 740, DateTimeKind.Local).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 740, DateTimeKind.Local).AddTicks(5548));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 740, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 740, DateTimeKind.Local).AddTicks(5692));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 740, DateTimeKind.Local).AddTicks(5698));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 740, DateTimeKind.Local).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 740, DateTimeKind.Local).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 740, DateTimeKind.Local).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 740, DateTimeKind.Local).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 740, DateTimeKind.Local).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 740, DateTimeKind.Local).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 740, DateTimeKind.Local).AddTicks(3688));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 733, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 738, DateTimeKind.Local).AddTicks(3643));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 738, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "AvatarPath", "CreatedOn", "Email", "FirstName", "IsAdmin", "IsBlocked", "IsDeleted", "LastName", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 5, null, new DateTime(2022, 9, 29, 10, 24, 50, 738, DateTimeKind.Local).AddTicks(3633), "beerGod@heaven.universe", "God", true, false, false, "Almighty", "BowToYourGod", "BeerGod" },
                    { 4, null, new DateTime(2022, 9, 29, 10, 24, 50, 738, DateTimeKind.Local).AddTicks(3471), "beerEmperor@rome.com", "Emperor", true, false, false, "Beer", "YourEMperorHasReturnted", "BeerEmperor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(5466));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(6560));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(6703));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(7668));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(9836));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 16, 31, 718, DateTimeKind.Local).AddTicks(4758));

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
        }
    }
}
