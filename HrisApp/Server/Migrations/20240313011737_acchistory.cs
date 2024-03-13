using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class acchistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "AssetAccessHistoryT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessHistoryT_EmployeeId",
                table: "AssetAccessHistoryT",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAccessHistoryT_EmployeeT_EmployeeId",
                table: "AssetAccessHistoryT",
                column: "EmployeeId",
                principalTable: "EmployeeT",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAccessHistoryT_EmployeeT_EmployeeId",
                table: "AssetAccessHistoryT");

            migrationBuilder.DropIndex(
                name: "IX_AssetAccessHistoryT_EmployeeId",
                table: "AssetAccessHistoryT");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AssetAccessHistoryT");
        }
    }
}
