using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG032220240211PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "AssetVehiclesT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AssetVehiclesT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AssetMasterT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AssetAccessoryT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AssetVehiclesT_CreatedById",
                table: "AssetVehiclesT",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetVehiclesT_EmployeeT_CreatedById",
                table: "AssetVehiclesT",
                column: "CreatedById",
                principalTable: "EmployeeT",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetVehiclesT_EmployeeT_CreatedById",
                table: "AssetVehiclesT");

            migrationBuilder.DropIndex(
                name: "IX_AssetVehiclesT_CreatedById",
                table: "AssetVehiclesT");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AssetVehiclesT");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AssetVehiclesT");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AssetMasterT");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AssetAccessoryT");
        }
    }
}
