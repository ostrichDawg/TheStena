using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheStena.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 7, 14, 0, 21, 52, DateTimeKind.Local).AddTicks(2210), "Dog" },
                    { 2, new DateTime(2023, 3, 7, 14, 0, 21, 52, DateTimeKind.Local).AddTicks(2219), "Cat" },
                    { 3, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pastor" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Downvotes", "Title", "Upvotes" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 7, 14, 0, 21, 52, DateTimeKind.Local).AddTicks(2298), 2, "Dog's post 1", 4 },
                    { 2, 1, new DateTime(2023, 3, 7, 14, 0, 21, 52, DateTimeKind.Local).AddTicks(2300), 7, "Dog's post 2", 60 },
                    { 3, 2, new DateTime(2023, 3, 7, 14, 0, 21, 52, DateTimeKind.Local).AddTicks(2301), 30, "Cat's post 1", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
