using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class AssetMainAcc2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedDate",
                table: "AssetMasterT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "AssetMasterT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_EmployeeId",
                table: "AssetMasterT",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMasterT_EmployeeT_EmployeeId",
                table: "AssetMasterT",
                column: "EmployeeId",
                principalTable: "EmployeeT",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetMasterT_EmployeeT_EmployeeId",
                table: "AssetMasterT");

            migrationBuilder.DropIndex(
                name: "IX_AssetMasterT_EmployeeId",
                table: "AssetMasterT");

            migrationBuilder.DropColumn(
                name: "AssignedDate",
                table: "AssetMasterT");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AssetMasterT");
        }
    }
}
