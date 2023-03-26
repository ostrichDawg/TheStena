using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheStena.Migrations
{
    /// <inheritdoc />
    public partial class NullablePostsInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 31, 3, 535, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 31, 3, 535, DateTimeKind.Local).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 31, 3, 535, DateTimeKind.Local).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 31, 3, 535, DateTimeKind.Local).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 8, 19, 31, 3, 535, DateTimeKind.Local).AddTicks(8710));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 7, 14, 0, 21, 52, DateTimeKind.Local).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 7, 14, 0, 21, 52, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 7, 14, 0, 21, 52, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 7, 14, 0, 21, 52, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 7, 14, 0, 21, 52, DateTimeKind.Local).AddTicks(2219));
        }
    }
}
