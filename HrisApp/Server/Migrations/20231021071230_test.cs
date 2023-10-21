using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "EmployeeT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AddressT",
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
                    table.PrimaryKey("PK_AddressT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollegeT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollSchoolLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollAward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollSchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollCourse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorateT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocSchoolLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocAward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocSchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocCourse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorateT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_Filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_Contenttype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Img_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Img_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpPictureT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_Filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_Contenttype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Img_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Img_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPictureT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasteralT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasSchoolLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasAward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasSchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasCourse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasteralT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherEducT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OthersSchoolType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OthersSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OthersSchoolLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OthersAward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OthersSchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OthersCourse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherEducT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriSchoolLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriAward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriSchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecondaryT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecSchoolLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecAward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecSchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeniorHST",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShsSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShsSchoolLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShsAward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShsSchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeniorHST", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressT");

            migrationBuilder.DropTable(
                name: "CollegeT");

            migrationBuilder.DropTable(
                name: "DoctorateT");

            migrationBuilder.DropTable(
                name: "DocumentT");

            migrationBuilder.DropTable(
                name: "EmpPictureT");

            migrationBuilder.DropTable(
                name: "MasteralT");

            migrationBuilder.DropTable(
                name: "OtherEducT");

            migrationBuilder.DropTable(
                name: "PrimaryT");

            migrationBuilder.DropTable(
                name: "SecondaryT");

            migrationBuilder.DropTable(
                name: "SeniorHST");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "EmployeeT");
        }
    }
}
