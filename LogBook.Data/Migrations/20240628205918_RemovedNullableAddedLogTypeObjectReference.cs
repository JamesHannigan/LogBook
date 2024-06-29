using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedNullableAddedLogTypeObjectReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Projects_ProjectId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "ActivityType",
                schema: "Data",
                table: "Logs",
                newName: "LogTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                schema: "Data",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_LogTypeId",
                schema: "Data",
                table: "Logs",
                column: "LogTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_LogTypes_LogTypeId",
                schema: "Data",
                table: "Logs",
                column: "LogTypeId",
                principalSchema: "Data",
                principalTable: "LogTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Projects_ProjectId",
                schema: "Data",
                table: "Logs",
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
                name: "FK_Logs_LogTypes_LogTypeId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Projects_ProjectId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_LogTypeId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "LogTypeId",
                schema: "Data",
                table: "Logs",
                newName: "ActivityType");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                schema: "Data",
                table: "Logs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Projects_ProjectId",
                schema: "Data",
                table: "Logs",
                column: "ProjectId",
                principalSchema: "Data",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
