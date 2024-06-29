using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLogTypeAndErrorLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ErrorLogs_Projects_ProjectId",
                schema: "Data",
                table: "ErrorLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_ErrorLog_ErrorLogId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropIndex(
                name: "IX_ErrorLogs_ProjectId",
                schema: "Data",
                table: "ErrorLogs");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "Data",
                table: "ErrorLogs");

            migrationBuilder.RenameColumn(
                name: "Reference",
                schema: "Data",
                table: "ErrorLogs",
                newName: "StackTrace");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Data",
                table: "ErrorLogs",
                newName: "Source");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                schema: "Data",
                table: "ErrorLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LogTypes",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogTypes_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Data",
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenant_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Data",
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogTypes_ProjectId",
                schema: "Data",
                table: "LogTypes",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_ProjectId",
                schema: "Data",
                table: "Tenant",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_ErrorLogs_ErrorLogId",
                schema: "Data",
                table: "Logs",
                column: "ErrorLogId",
                principalSchema: "Data",
                principalTable: "ErrorLogs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_ErrorLogs_ErrorLogId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.DropTable(
                name: "LogTypes",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "Tenant",
                schema: "Data");

            migrationBuilder.DropColumn(
                name: "Message",
                schema: "Data",
                table: "ErrorLogs");

            migrationBuilder.RenameColumn(
                name: "StackTrace",
                schema: "Data",
                table: "ErrorLogs",
                newName: "Reference");

            migrationBuilder.RenameColumn(
                name: "Source",
                schema: "Data",
                table: "ErrorLogs",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                schema: "Data",
                table: "ErrorLogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErrorLogs_ProjectId",
                schema: "Data",
                table: "ErrorLogs",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorLogs_Projects_ProjectId",
                schema: "Data",
                table: "ErrorLogs",
                column: "ProjectId",
                principalSchema: "Data",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_ErrorLog_ErrorLogId",
                schema: "Data",
                table: "Logs",
                column: "ErrorLogId",
                principalTable: "ErrorLog",
                principalColumn: "Id");
        }
    }
}
