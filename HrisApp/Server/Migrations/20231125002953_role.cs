using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "App_PosApplied",
                table: "ApplicantT",
                newName: "App_SourceApp");

            migrationBuilder.RenameColumn(
                name: "App_ContactNo2",
                table: "ApplicantT",
                newName: "App_PosApplied2");

            migrationBuilder.RenameColumn(
                name: "App_ContactNo1",
                table: "ApplicantT",
                newName: "App_PosApplied1");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserMasterT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "App_ContactNo",
                table: "ApplicantT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "App_ExpSalary",
                table: "ApplicantT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "App_DateTo",
                table: "App_ProfBackgroundT",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "App_DateFrom",
                table: "App_ProfBackgroundT",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "App_AddressT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentBrgy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAdd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentBrgy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_AddressT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_ProfBackgroundT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicSalary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RSLeaving = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_ProfBackgroundT", x => x.Id);
                });

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "App_AddressT");

            migrationBuilder.DropTable(
                name: "Emp_ProfBackgroundT");



            migrationBuilder.DropColumn(
                name: "App_ContactNo",
                table: "ApplicantT");

            migrationBuilder.DropColumn(
                name: "App_ExpSalary",
                table: "ApplicantT");

            migrationBuilder.RenameColumn(
                name: "App_SourceApp",
                table: "ApplicantT",
                newName: "App_PosApplied");

            migrationBuilder.RenameColumn(
                name: "App_PosApplied2",
                table: "ApplicantT",
                newName: "App_ContactNo2");

            migrationBuilder.RenameColumn(
                name: "App_PosApplied1",
                table: "ApplicantT",
                newName: "App_ContactNo1");


            migrationBuilder.AlterColumn<DateTime>(
                name: "App_DateTo",
                table: "App_ProfBackgroundT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "App_DateFrom",
                table: "App_ProfBackgroundT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

        }
    }
}
