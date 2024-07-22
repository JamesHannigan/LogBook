using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedAssigneeAndInviteeToProjectAssignments2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectsAssignments",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    AssigneeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InvitedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InviteAccepted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsAssignments_ApplicationUser_AssigneeId",
                        column: x => x.AssigneeId,
                        principalSchema: "System",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectsAssignments_ApplicationUser_InvitedById",
                        column: x => x.InvitedById,
                        principalSchema: "System",
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectsAssignments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Data",
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsAssignments_AssigneeId",
                schema: "Data",
                table: "ProjectsAssignments",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsAssignments_InvitedById",
                schema: "Data",
                table: "ProjectsAssignments",
                column: "InvitedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsAssignments_ProjectId",
                schema: "Data",
                table: "ProjectsAssignments",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectsAssignments",
                schema: "Data");
        }
    }
}
