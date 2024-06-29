using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedProjectIDFieldToLogType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogTypes_Projects_ProjectId",
                schema: "Data",
                table: "LogTypes");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                schema: "Data",
                table: "LogTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LogTypes_Projects_ProjectId",
                schema: "Data",
                table: "LogTypes",
                column: "ProjectId",
                principalSchema: "Data",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogTypes_Projects_ProjectId",
                schema: "Data",
                table: "LogTypes");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                schema: "Data",
                table: "LogTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LogTypes_Projects_ProjectId",
                schema: "Data",
                table: "LogTypes",
                column: "ProjectId",
                principalSchema: "Data",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
