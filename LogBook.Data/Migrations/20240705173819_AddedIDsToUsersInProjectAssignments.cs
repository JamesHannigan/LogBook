using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIDsToUsersInProjectAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsAssignments_ApplicationUser_AssigneeId",
                schema: "Data",
                table: "ProjectsAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsAssignments_ApplicationUser_InvitedById",
                schema: "Data",
                table: "ProjectsAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsAssignments_AssigneeId",
                schema: "Data",
                table: "ProjectsAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsAssignments_InvitedById",
                schema: "Data",
                table: "ProjectsAssignments");

            migrationBuilder.AlterColumn<Guid>(
                name: "InvitedById",
                schema: "Data",
                table: "ProjectsAssignments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AssigneeId",
                schema: "Data",
                table: "ProjectsAssignments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssigneeId1",
                schema: "Data",
                table: "ProjectsAssignments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvitedById1",
                schema: "Data",
                table: "ProjectsAssignments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsAssignments_AssigneeId1",
                schema: "Data",
                table: "ProjectsAssignments",
                column: "AssigneeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsAssignments_InvitedById1",
                schema: "Data",
                table: "ProjectsAssignments",
                column: "InvitedById1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsAssignments_ApplicationUser_AssigneeId1",
                schema: "Data",
                table: "ProjectsAssignments",
                column: "AssigneeId1",
                principalSchema: "System",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsAssignments_ApplicationUser_InvitedById1",
                schema: "Data",
                table: "ProjectsAssignments",
                column: "InvitedById1",
                principalSchema: "System",
                principalTable: "ApplicationUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsAssignments_ApplicationUser_AssigneeId1",
                schema: "Data",
                table: "ProjectsAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsAssignments_ApplicationUser_InvitedById1",
                schema: "Data",
                table: "ProjectsAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsAssignments_AssigneeId1",
                schema: "Data",
                table: "ProjectsAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsAssignments_InvitedById1",
                schema: "Data",
                table: "ProjectsAssignments");

            migrationBuilder.DropColumn(
                name: "AssigneeId1",
                schema: "Data",
                table: "ProjectsAssignments");

            migrationBuilder.DropColumn(
                name: "InvitedById1",
                schema: "Data",
                table: "ProjectsAssignments");

            migrationBuilder.AlterColumn<string>(
                name: "InvitedById",
                schema: "Data",
                table: "ProjectsAssignments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssigneeId",
                schema: "Data",
                table: "ProjectsAssignments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsAssignments_ApplicationUser_AssigneeId",
                schema: "Data",
                table: "ProjectsAssignments",
                column: "AssigneeId",
                principalSchema: "System",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsAssignments_ApplicationUser_InvitedById",
                schema: "Data",
                table: "ProjectsAssignments",
                column: "InvitedById",
                principalSchema: "System",
                principalTable: "ApplicationUser",
                principalColumn: "Id");
        }
    }
}
