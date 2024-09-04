using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG090420241106 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SubPositionT");

            migrationBuilder.DropColumn(
                name: "PosCode",
                table: "SubPositionT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SubPositionT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PosCode",
                table: "SubPositionT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
