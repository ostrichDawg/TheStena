using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheStena.Migrations
{
    /// <inheritdoc />
    public partial class UserPasswordHashAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

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
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 13, 21, 26, 38, 20, DateTimeKind.Local).AddTicks(6939), new byte[] { 124, 106, 24, 11, 54, 137, 106, 10, 140, 2, 120, 126, 234, 251, 14, 76 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2023, 3, 13, 21, 26, 38, 20, DateTimeKind.Local).AddTicks(6955), new byte[] { 108, 183, 95, 101, 42, 155, 82, 121, 142, 182, 207, 34, 1, 5, 124, 115 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: new byte[] { 129, 155, 6, 67, 214, 184, 157, 201, 181, 121, 253, 252, 144, 148, 242, 142 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

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
    }
}
