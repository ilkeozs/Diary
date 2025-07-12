using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiaryApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaryEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryEntries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { 1, "This is the content of the first diary entry. This is a test entry to see if the data is being saved correctly.", new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "First Diary Entry" },
                    { 2, "This is the content of the second diary entry. This is a test entry to see if the data is being saved correctly.", new DateTime(2025, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second Diary Entry" },
                    { 3, "This is the content of the third diary entry. This is a test entry to see if the data is being saved correctly.", new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Third Diary Entry" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryEntries");
        }
    }
}
