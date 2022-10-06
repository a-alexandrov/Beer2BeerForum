using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer2Beer.Data.Migrations
{
    public partial class AddImageToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "AvatarImage",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 369, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 369, DateTimeKind.Local).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 369, DateTimeKind.Local).AddTicks(5877));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 369, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 369, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 369, DateTimeKind.Local).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 369, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 369, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 369, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 369, DateTimeKind.Local).AddTicks(4338));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 369, DateTimeKind.Local).AddTicks(4648));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 369, DateTimeKind.Local).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 364, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 368, DateTimeKind.Local).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 368, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 368, DateTimeKind.Local).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 5, 21, 33, 33, 368, DateTimeKind.Local).AddTicks(1721));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarImage",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "AvatarPath",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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
                column: "CreatedOn",
                value: new DateTime(2022, 10, 4, 17, 9, 0, 964, DateTimeKind.Local).AddTicks(6559));
        }
    }
}
