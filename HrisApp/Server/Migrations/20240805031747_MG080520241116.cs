using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG080520241116 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "AccessImgLogT",
                newName: "FolderTitleVerId");

            migrationBuilder.AddColumn<string>(
                name: "FolderTitle",
                table: "AccessImgLogT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FolderTitle",
                table: "AccessImgLogT");

            migrationBuilder.RenameColumn(
                name: "FolderTitleVerId",
                table: "AccessImgLogT",
                newName: "Remarks");
        }
    }
}
