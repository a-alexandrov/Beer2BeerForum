using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer2Beer.Data.Migrations
{
    public partial class AddedAdminsToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 202, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "ID", "CreatedOn", "IsDeleted", "PhoneNumber", "UserID" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 9, 29, 10, 28, 5, 202, DateTimeKind.Local).AddTicks(6816), false, "029212100", 2 },
                    { 3, new DateTime(2022, 9, 29, 10, 28, 5, 202, DateTimeKind.Local).AddTicks(6880), false, null, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 203, DateTimeKind.Local).AddTicks(925));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 203, DateTimeKind.Local).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 203, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 203, DateTimeKind.Local).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 203, DateTimeKind.Local).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 203, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 203, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 203, DateTimeKind.Local).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 203, DateTimeKind.Local).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 202, DateTimeKind.Local).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 203, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 203, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 196, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 200, DateTimeKind.Local).AddTicks(9809));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 200, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 200, DateTimeKind.Local).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 28, 5, 200, DateTimeKind.Local).AddTicks(9799));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "ID",
                keyValue: 3);

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 738, DateTimeKind.Local).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 9, 29, 10, 24, 50, 738, DateTimeKind.Local).AddTicks(3633));
        }
    }
}
