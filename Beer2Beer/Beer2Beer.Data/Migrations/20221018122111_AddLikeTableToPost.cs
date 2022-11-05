using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer2Beer.Data.Migrations
{
    public partial class AddLikeTableToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    IsLiked = table.Column<bool>(nullable: true),
                    PostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 627, DateTimeKind.Local).AddTicks(7412));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 627, DateTimeKind.Local).AddTicks(8297));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 627, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 627, DateTimeKind.Local).AddTicks(8354));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 627, DateTimeKind.Local).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 627, DateTimeKind.Local).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 627, DateTimeKind.Local).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 628, DateTimeKind.Local).AddTicks(566));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 628, DateTimeKind.Local).AddTicks(662));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 627, DateTimeKind.Local).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 627, DateTimeKind.Local).AddTicks(6812));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 627, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 618, DateTimeKind.Local).AddTicks(951));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 625, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 625, DateTimeKind.Local).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 625, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 18, 15, 21, 10, 625, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostID",
                table: "Likes",
                column: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1883));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 704, DateTimeKind.Local).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 700, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 703, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 703, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 703, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 10, 14, 0, 48, 5, 703, DateTimeKind.Local).AddTicks(348));
        }
    }
}
