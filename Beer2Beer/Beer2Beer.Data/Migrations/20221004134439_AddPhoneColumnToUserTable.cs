using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer2Beer.Data.Migrations
{
    public partial class AddPhoneColumnToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                nullable: true);

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
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 44, 39, 394, DateTimeKind.Local).AddTicks(6510));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 156, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 156, DateTimeKind.Local).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 156, DateTimeKind.Local).AddTicks(913));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 156, DateTimeKind.Local).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 156, DateTimeKind.Local).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 156, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 156, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 156, DateTimeKind.Local).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 156, DateTimeKind.Local).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 155, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 156, DateTimeKind.Local).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 156, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 152, DateTimeKind.Local).AddTicks(8474));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 154, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 154, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 154, DateTimeKind.Local).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 16, 11, 11, 154, DateTimeKind.Local).AddTicks(9814));
        }
    }
}
