using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleCode",
                table: "UserRoleT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "UserRoleT",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "RoleCode" },
                values: new object[] { "Administrator", "Admin" });

            migrationBuilder.UpdateData(
                table: "UserRoleT",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleCode",
                value: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleCode",
                table: "UserRoleT");

            migrationBuilder.UpdateData(
                table: "UserRoleT",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Admin");
        }
    }
}
