using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedManyFieldsToTheModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StackTrace",
                schema: "Data",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "SystemTimestamp",
                schema: "Data",
                table: "Logs",
                newName: "Created");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "Data",
                table: "Tenant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Data",
                table: "Tenant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                schema: "Data",
                table: "Tenant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                schema: "Data",
                table: "Tenant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                schema: "Data",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "Data",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Data",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ErrorLogId",
                schema: "Data",
                table: "Logs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_ProjectId",
                schema: "Data",
                table: "Tenant",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ErrorLogId",
                schema: "Data",
                table: "Logs",
                column: "ErrorLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_ErrorLog_ErrorLogId",
                schema: "Data",
                table: "Logs",
                column: "ErrorLogId",
                principalTable: "ErrorLog",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_Projects_ProjectId",
                schema: "Data",
                table: "Tenant",
                column: "ProjectId",
                principalSchema: "Data",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_ErrorLog_ErrorLogId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_Projects_ProjectId",
                schema: "Data",
                table: "Tenant");

            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropIndex(
                name: "IX_Tenant_ProjectId",
                schema: "Data",
                table: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_Logs_ErrorLogId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "Data",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Data",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "Data",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "Reference",
                schema: "Data",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "ApiKey",
                schema: "Data",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "Data",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Data",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ErrorLogId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "Created",
                schema: "Data",
                table: "Logs",
                newName: "SystemTimestamp");

            migrationBuilder.AddColumn<string>(
                name: "StackTrace",
                schema: "Data",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
