using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class ASsetMain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAccessoryT_AssetMasterT_AssetMasterTId",
                table: "AssetAccessoryT");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMasterT_AssetAccessoryT_AssetAccessoryId",
                table: "AssetMasterT");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMasterT_EmployeeT_EmployeeId",
                table: "AssetMasterT");

            migrationBuilder.DropIndex(
                name: "IX_AssetMasterT_AssetAccessoryId",
                table: "AssetMasterT");

            migrationBuilder.DropIndex(
                name: "IX_AssetMasterT_EmployeeId",
                table: "AssetMasterT");

            migrationBuilder.DropIndex(
                name: "IX_AssetAccessoryT_AssetMasterTId",
                table: "AssetAccessoryT");

            migrationBuilder.DropColumn(
                name: "AssetAccessoryId",
                table: "AssetMasterT");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AssetMasterT");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "AssetMasterT");

            migrationBuilder.DropColumn(
                name: "AssetMasterTId",
                table: "AssetAccessoryT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssetAccessoryId",
                table: "AssetMasterT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "AssetMasterT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListId",
                table: "AssetMasterT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AssetMasterTId",
                table: "AssetAccessoryT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_AssetAccessoryId",
                table: "AssetMasterT",
                column: "AssetAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_EmployeeId",
                table: "AssetMasterT",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoryT_AssetMasterTId",
                table: "AssetAccessoryT",
                column: "AssetMasterTId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAccessoryT_AssetMasterT_AssetMasterTId",
                table: "AssetAccessoryT",
                column: "AssetMasterTId",
                principalTable: "AssetMasterT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMasterT_AssetAccessoryT_AssetAccessoryId",
                table: "AssetMasterT",
                column: "AssetAccessoryId",
                principalTable: "AssetAccessoryT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMasterT_EmployeeT_EmployeeId",
                table: "AssetMasterT",
                column: "EmployeeId",
                principalTable: "EmployeeT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
