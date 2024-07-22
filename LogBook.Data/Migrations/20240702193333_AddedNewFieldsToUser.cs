using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewFieldsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "System",
                table: "ApplicationUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "System",
                table: "ApplicationUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Registered",
                schema: "System",
                table: "ApplicationUser",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "System",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "System",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "Registered",
                schema: "System",
                table: "ApplicationUser");
        }
    }
}
