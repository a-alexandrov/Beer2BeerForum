using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer2Beer.Data.Migrations
{
    public partial class TestSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "AvatarPath", "CreatedOn", "Email", "FirstName", "IsAdmin", "IsBlocked", "IsDeleted", "LastName", "PasswordHash", "Username" },
                values: new object[] { 1, null, new DateTime(2022, 9, 28, 11, 55, 41, 73, DateTimeKind.Local).AddTicks(7168), "beerKing@abv.bg", "Forum", true, false, false, "King", "THeKingIsHere", "BeerKing" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "AvatarPath", "CreatedOn", "Email", "FirstName", "IsAdmin", "IsBlocked", "IsDeleted", "LastName", "PasswordHash", "Username" },
                values: new object[] { 2, null, new DateTime(2022, 9, 28, 11, 55, 41, 77, DateTimeKind.Local).AddTicks(7614), "beerPeasent@mail.bg", "Beer", false, false, false, "Peasunt", "ThePeasentIsHere", "BeerPeasunt" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "AvatarPath", "CreatedOn", "Email", "FirstName", "IsAdmin", "IsBlocked", "IsDeleted", "LastName", "PasswordHash", "Username" },
                values: new object[] { 3, null, new DateTime(2022, 9, 28, 11, 55, 41, 77, DateTimeKind.Local).AddTicks(7757), "beerSlave@mail.bg", "Beer", false, false, false, "Slave", "TheSlaveIsHere", "BeerSlave" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "ID", "CreatedOn", "IsDeleted", "PhoneNumber", "UserID" },
                values: new object[] { 1, new DateTime(2022, 9, 28, 11, 55, 41, 79, DateTimeKind.Local).AddTicks(3666), false, "0888888888", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");
        }
    }
}
