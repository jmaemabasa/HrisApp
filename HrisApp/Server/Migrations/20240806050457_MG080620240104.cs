using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG080620240104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "MainAssetImgLogT",
                newName: "FolderTitleVerId");

            migrationBuilder.AddColumn<string>(
                name: "FolderTitle",
                table: "MainAssetImgLogT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FolderTitle",
                table: "MainAssetImgLogT");

            migrationBuilder.RenameColumn(
                name: "FolderTitleVerId",
                table: "MainAssetImgLogT",
                newName: "Remarks");
        }
    }
}
