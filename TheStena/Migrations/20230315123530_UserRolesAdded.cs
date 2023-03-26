using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheStena.Migrations
{
    /// <inheritdoc />
    public partial class UserRolesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 15, 18, 35, 30, 568, DateTimeKind.Local).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 15, 18, 35, 30, 568, DateTimeKind.Local).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 15, 18, 35, 30, 568, DateTimeKind.Local).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Role" },
                values: new object[] { new DateTime(2023, 3, 15, 18, 35, 30, 568, DateTimeKind.Local).AddTicks(3938), "OP" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Role" },
                values: new object[] { new DateTime(2023, 3, 15, 18, 35, 30, 568, DateTimeKind.Local).AddTicks(3963), "OP" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Role",
                value: "OP");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Name", "PasswordHash", "Role" },
                values: new object[] { 4, new DateTime(2023, 3, 15, 18, 35, 30, 568, DateTimeKind.Local).AddTicks(3989), "Admin", new byte[] { 95, 77, 204, 59, 90, 167, 101, 214, 29, 131, 39, 222, 184, 130, 207, 153 }, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 13, 21, 26, 38, 20, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 13, 21, 26, 38, 20, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 13, 21, 26, 38, 20, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 13, 21, 26, 38, 20, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 13, 21, 26, 38, 20, DateTimeKind.Local).AddTicks(6955));
        }
    }
}
