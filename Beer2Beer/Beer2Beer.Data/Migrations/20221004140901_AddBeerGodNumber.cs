using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer2Beer.Data.Migrations
{
    public partial class AddBeerGodNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 965, DateTimeKind.Local).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 965, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 965, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 965, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 965, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 965, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 965, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 965, DateTimeKind.Local).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 965, DateTimeKind.Local).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 965, DateTimeKind.Local).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 965, DateTimeKind.Local).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 965, DateTimeKind.Local).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 962, DateTimeKind.Local).AddTicks(4018));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 964, DateTimeKind.Local).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 964, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 964, DateTimeKind.Local).AddTicks(6469));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedOn", "PhoneNumber" },
                values: new object[] { new DateTime(2022, 10, 4, 17, 9, 0, 964, DateTimeKind.Local).AddTicks(6559), "0883778833" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 396, DateTimeKind.Local).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 396, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 395, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 392, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 394, DateTimeKind.Local).AddTicks(6517));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 394, DateTimeKind.Local).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 394, DateTimeKind.Local).AddTicks(6398));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedOn", "PhoneNumber" },
                values: new object[] { new DateTime(2022, 10, 4, 16, 44, 39, 394, DateTimeKind.Local).AddTicks(6510), null });
        }
    }
}
