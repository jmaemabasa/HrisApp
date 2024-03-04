using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class AssetMaster2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "AssetMasterHistoryT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterHistoryT_EmployeeId",
                table: "AssetMasterHistoryT",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMasterHistoryT_EmployeeT_EmployeeId",
                table: "AssetMasterHistoryT",
                column: "EmployeeId",
                principalTable: "EmployeeT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetMasterHistoryT_EmployeeT_EmployeeId",
                table: "AssetMasterHistoryT");

            migrationBuilder.DropIndex(
                name: "IX_AssetMasterHistoryT_EmployeeId",
                table: "AssetMasterHistoryT");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AssetMasterHistoryT");
        }
    }
}
