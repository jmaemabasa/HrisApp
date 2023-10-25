using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class licensetrainings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenseT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Examination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfMembership = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingT", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "InactiveStatusT",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "InactiveStatusT",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Resigned");

            migrationBuilder.UpdateData(
                table: "InactiveStatusT",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Terminated");

            migrationBuilder.UpdateData(
                table: "InactiveStatusT",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Awol");

            migrationBuilder.InsertData(
                table: "InactiveStatusT",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Retired" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseT");

            migrationBuilder.DropTable(
                name: "TrainingT");

            migrationBuilder.DeleteData(
                table: "InactiveStatusT",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "InactiveStatusT",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Resigned");

            migrationBuilder.UpdateData(
                table: "InactiveStatusT",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Terminated");

            migrationBuilder.UpdateData(
                table: "InactiveStatusT",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Awol");

            migrationBuilder.UpdateData(
                table: "InactiveStatusT",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Retired");
        }
    }
}
