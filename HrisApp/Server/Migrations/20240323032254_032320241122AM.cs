using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class _032320241122AM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MacAddress",
                table: "AssetVehiclesT");

            migrationBuilder.DropColumn(
                name: "Processor",
                table: "AssetVehiclesT");

            migrationBuilder.DropColumn(
                name: "RAM",
                table: "AssetVehiclesT");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "AssetVehiclesT");

            migrationBuilder.DropColumn(
                name: "Storage",
                table: "AssetVehiclesT");

            migrationBuilder.DropColumn(
                name: "StorageType",
                table: "AssetVehiclesT");

            migrationBuilder.CreateTable(
                name: "VehicleRemarksT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VhcAssetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRemarksT", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleRemarksT");

            migrationBuilder.AddColumn<string>(
                name: "MacAddress",
                table: "AssetVehiclesT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Processor",
                table: "AssetVehiclesT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RAM",
                table: "AssetVehiclesT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "AssetVehiclesT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Storage",
                table: "AssetVehiclesT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StorageType",
                table: "AssetVehiclesT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
