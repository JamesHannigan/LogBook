using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLevelToLogTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "Data",
                table: "LogTypes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                schema: "Data",
                table: "LogTypes");
        }
    }
}
