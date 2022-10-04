using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer2Beer.Data.Migrations
{
    public partial class RemoveAdminTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Admins_Users_ID",
                        column: x => x.ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "ID", "CreatedOn", "IsDeleted", "PhoneNumber", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 29, 10, 28, 5, 202, DateTimeKind.Local).AddTicks(5750), false, "0888888888", 1 },
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
    }
}
