using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class user1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "UserMasterT",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "UserMasterT",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "UserMasterT",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "UserMasterT",
                newName: "Email");
        }
    }
}
