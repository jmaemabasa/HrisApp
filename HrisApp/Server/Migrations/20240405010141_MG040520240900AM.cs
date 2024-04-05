using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG040520240900AM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InActiveDate",
                table: "SubPositionT",
                newName: "VacantDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "SubPositionT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateInactive",
                table: "SubPositionT",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "SubPositionT");

            migrationBuilder.DropColumn(
                name: "DateInactive",
                table: "SubPositionT");

            migrationBuilder.RenameColumn(
                name: "VacantDate",
                table: "SubPositionT",
                newName: "InActiveDate");
        }
    }
}
