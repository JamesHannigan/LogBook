using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectAndTenantFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                schema: "Data",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                schema: "Data",
                table: "Logs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ProjectId",
                schema: "Data",
                table: "Logs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_TenantId",
                schema: "Data",
                table: "Logs",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Projects_ProjectId",
                schema: "Data",
                table: "Logs",
                column: "ProjectId",
                principalSchema: "Data",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Tenant_TenantId",
                schema: "Data",
                table: "Logs",
                column: "TenantId",
                principalSchema: "Data",
                principalTable: "Tenant",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Projects_ProjectId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Tenant_TenantId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_ProjectId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_TenantId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                schema: "Data",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "Data",
                table: "Logs");
        }
    }
}
