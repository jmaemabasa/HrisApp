using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class Asset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "AssetMasterT",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "AssetMasterT",
                newName: "JMCode");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "AssetAccessoryT",
                newName: "JMCode");

            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "AssetAccessoryT",
                newName: "UnassignedDateMainAss");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "AssetAccessoryT",
                newName: "Barcode");

            migrationBuilder.RenameColumn(
                name: "Asset",
                table: "AssetAccessoryT",
                newName: "AssetCode");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "AssetMasterT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "AssetMasterT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "AssetImageT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedDateMainAss",
                table: "AssetAccessoryT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AssetAccessoryT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "AssetAccessoryT",
                type: "int",
                nullable: false,
                defaultValue: 0);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "AssetMasterT");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "AssetMasterT");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "AssetImageT");

            migrationBuilder.DropColumn(
                name: "AssignedDateMainAss",
                table: "AssetAccessoryT");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AssetAccessoryT");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "AssetAccessoryT");

            migrationBuilder.RenameColumn(
                name: "JMCode",
                table: "AssetMasterT",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "AssetMasterT",
                newName: "DateAdded");

            migrationBuilder.RenameColumn(
                name: "UnassignedDateMainAss",
                table: "AssetAccessoryT",
                newName: "DateAdded");

            migrationBuilder.RenameColumn(
                name: "JMCode",
                table: "AssetAccessoryT",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "AssetAccessoryT",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "AssetCode",
                table: "AssetAccessoryT",
                newName: "Asset");
        }
    }
}
