using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditlogsT_UserMasterT_UserId",
                table: "AuditlogsT");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AuditlogsT",
                newName: "EmployeeUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AuditlogsT_UserId",
                table: "AuditlogsT",
                newName: "IX_AuditlogsT_EmployeeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditlogsT_EmployeeT_EmployeeUserId",
                table: "AuditlogsT",
                column: "EmployeeUserId",
                principalTable: "EmployeeT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditlogsT_EmployeeT_EmployeeUserId",
                table: "AuditlogsT");

            migrationBuilder.RenameColumn(
                name: "EmployeeUserId",
                table: "AuditlogsT",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AuditlogsT_EmployeeUserId",
                table: "AuditlogsT",
                newName: "IX_AuditlogsT_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditlogsT_UserMasterT_UserId",
                table: "AuditlogsT",
                column: "UserId",
                principalTable: "UserMasterT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
