using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class _032220240911AM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "AssetMasterT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "AssetAccessoryT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_CreatedById",
                table: "AssetMasterT",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoryT_CreatedById",
                table: "AssetAccessoryT",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAccessoryT_EmployeeT_CreatedById",
                table: "AssetAccessoryT",
                column: "CreatedById",
                principalTable: "EmployeeT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMasterT_EmployeeT_CreatedById",
                table: "AssetMasterT",
                column: "CreatedById",
                principalTable: "EmployeeT",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAccessoryT_EmployeeT_CreatedById",
                table: "AssetAccessoryT");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMasterT_EmployeeT_CreatedById",
                table: "AssetMasterT");

            migrationBuilder.DropIndex(
                name: "IX_AssetMasterT_CreatedById",
                table: "AssetMasterT");

            migrationBuilder.DropIndex(
                name: "IX_AssetAccessoryT_CreatedById",
                table: "AssetAccessoryT");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AssetMasterT");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AssetAccessoryT");
        }
    }
}
