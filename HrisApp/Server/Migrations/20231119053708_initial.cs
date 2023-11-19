using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_ChildrenT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_ChildrenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_ChildrenOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ChildrenT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_CollegeT",
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
                    table.PrimaryKey("PK_App_CollegeT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_DoctorateT",
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
                    table.PrimaryKey("PK_App_DoctorateT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_LicenseT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Examination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_LicenseT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_MasteralT",
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
                    table.PrimaryKey("PK_App_MasteralT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_OtherAwardsT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_OtherAwardsT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_OtherEducT",
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
                    table.PrimaryKey("PK_App_OtherEducT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_PrimaryT",
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
                    table.PrimaryKey("PK_App_PrimaryT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_ProfBackgroundT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    App_DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    App_CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_BasicSalary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_RSLeaving = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ProfBackgroundT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_SecondaryT",
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
                    table.PrimaryKey("PK_App_SecondaryT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_SeniorHST",
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
                    table.PrimaryKey("PK_App_SeniorHST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_SiblingT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_SiblingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_SiblingOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_SiblingT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_TrainingT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorSpeaker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_TrainingT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashBondT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBondT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CivilStatusT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilStatusT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DivisionT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmerRelationshipT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmerRelationshipT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_AddressT",
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
                    table.PrimaryKey("PK_Emp_AddressT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_CollegeT",
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
                    table.PrimaryKey("PK_Emp_CollegeT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_DoctorateT",
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
                    table.PrimaryKey("PK_Emp_DoctorateT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_EmploymentDateT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpmentStatusId = table.Column<int>(type: "int", nullable: false),
                    ProbationStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProbationEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CasualStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CasualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegularizationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResignationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FixedStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FixedEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_EmploymentDateT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_LicenseT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Examination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_LicenseT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_MasteralT",
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
                    table.PrimaryKey("PK_Emp_MasteralT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_OtherEducT",
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
                    table.PrimaryKey("PK_Emp_OtherEducT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_PrimaryT",
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
                    table.PrimaryKey("PK_Emp_PrimaryT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_SecondaryT",
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
                    table.PrimaryKey("PK_Emp_SecondaryT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_SeniorHST",
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
                    table.PrimaryKey("PK_Emp_SeniorHST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_TrainingT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorSpeaker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_TrainingT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentStatusT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentStatusT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenderT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InactiveStatusT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InactiveStatusT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    Plantilla = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RateTypeT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateTypeT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReligionT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReligionT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestDayT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestDayT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTypeT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeOut = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTypeT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_Filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_Contenttype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Img_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Img_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentT_DepartmentT_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentT_DivisionT_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "DivisionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpPictureT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_Filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_Contenttype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Img_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Img_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPictureT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpPictureT_DepartmentT_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpPictureT_DivisionT_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "DivisionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_PosApplied = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_PresSalary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_Suffix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_ContactNo1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_ContactNo2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    App_Age = table.Column<int>(type: "int", nullable: false),
                    App_GenderId = table.Column<int>(type: "int", nullable: false),
                    App_Citizenship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_CivilStatusId = table.Column<int>(type: "int", nullable: false),
                    App_ReligionId = table.Column<int>(type: "int", nullable: false),
                    App_Height = table.Column<int>(type: "int", nullable: true),
                    App_Weight = table.Column<int>(type: "int", nullable: true),
                    App_TIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_SSS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_PagIbig = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_Philhealth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_EmerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_EmerRelationshipId = table.Column<int>(type: "int", nullable: false),
                    App_EmerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_EmerMobNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_SpouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_SpouseOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantT_CivilStatusT_App_CivilStatusId",
                        column: x => x.App_CivilStatusId,
                        principalTable: "CivilStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantT_EmerRelationshipT_App_EmerRelationshipId",
                        column: x => x.App_EmerRelationshipId,
                        principalTable: "EmerRelationshipT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantT_GenderT_App_GenderId",
                        column: x => x.App_GenderId,
                        principalTable: "GenderT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantT_ReligionT_App_ReligionId",
                        column: x => x.App_ReligionId,
                        principalTable: "ReligionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emp_PayrollT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RateTypeId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashbondId = table.Column<int>(type: "int", nullable: false),
                    MealAllowance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BiometricID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAcc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TINNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSSNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhilHealthNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HDMFNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestDayId = table.Column<int>(type: "int", nullable: false),
                    ScheduleTypeId = table.Column<int>(type: "int", nullable: false),
                    Paytype = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_PayrollT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emp_PayrollT_CashBondT_CashbondId",
                        column: x => x.CashbondId,
                        principalTable: "CashBondT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emp_PayrollT_RateTypeT_RateTypeId",
                        column: x => x.RateTypeId,
                        principalTable: "RateTypeT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emp_PayrollT_RestDayT_RestDayId",
                        column: x => x.RestDayId,
                        principalTable: "RestDayT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emp_PayrollT_ScheduleTypeT_ScheduleTypeId",
                        column: x => x.ScheduleTypeId,
                        principalTable: "ScheduleTypeT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    CivilStatusId = table.Column<int>(type: "int", nullable: false),
                    ReligionId = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmerRelationshipId = table.Column<int>(type: "int", nullable: false),
                    EmerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmerMobNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateHired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateInactiveStatus = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmploymentStatusId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    InactiveStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeT_AreaT_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AreaT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_CivilStatusT_CivilStatusId",
                        column: x => x.CivilStatusId,
                        principalTable: "CivilStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_DepartmentT_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_DivisionT_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "DivisionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_EmerRelationshipT_EmerRelationshipId",
                        column: x => x.EmerRelationshipId,
                        principalTable: "EmerRelationshipT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_EmploymentStatusT_EmploymentStatusId",
                        column: x => x.EmploymentStatusId,
                        principalTable: "EmploymentStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_GenderT_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GenderT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_InactiveStatusT_InactiveStatusId",
                        column: x => x.InactiveStatusId,
                        principalTable: "InactiveStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_PositionT_PositionId",
                        column: x => x.PositionId,
                        principalTable: "PositionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_ReligionT_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "ReligionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_StatusT_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMasterT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LoginStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferralCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMasterT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMasterT_EmployeeT_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditlogsT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditlogsT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditlogsT_UserMasterT_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMasterT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AreaT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Davao" },
                    { 2, "Digos" },
                    { 3, "Kidapawan" },
                    { 4, "Cotabato" },
                    { 5, "Calinan" },
                    { 6, "Gumalang" }
                });

            migrationBuilder.InsertData(
                table: "CashBondT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Yes" },
                    { 2, "No" }
                });

            migrationBuilder.InsertData(
                table: "CivilStatusT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Single" },
                    { 2, "Married" },
                    { 3, "Widowed" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentT",
                columns: new[] { "Id", "DivisionId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Sonic 1" },
                    { 2, 1, "Sonic 2" },
                    { 3, 1, "Sonic 3 Digos" },
                    { 4, 1, "Sonic 3 Kidapawan" },
                    { 5, 1, "Sonic 3 Cotabato" },
                    { 6, 1, "URIC" },
                    { 7, 1, "UFS" },
                    { 8, 1, "GCash" },
                    { 9, 2, "General Accounting" },
                    { 10, 2, "Sales Accounting" },
                    { 11, 2, "Information Technology" },
                    { 12, 2, "Treasury" },
                    { 16, 3, "Warehouse" },
                    { 17, 3, "Transport" },
                    { 18, 3, "Inventory Planning and Principal Relations" },
                    { 19, 3, "Order Processing" },
                    { 20, 3, "Logistics" },
                    { 21, 4, "Human Resource" },
                    { 22, 4, "General Services" },
                    { 23, 5, "Canaan" },
                    { 24, 5, "RTL" },
                    { 25, 5, "Pullet" }
                });

            migrationBuilder.InsertData(
                table: "DivisionT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sales Operations" },
                    { 2, "FAMS" },
                    { 3, "Supply Chain Management Service" },
                    { 4, "Central Administration" },
                    { 5, "Agro Industrial" }
                });

            migrationBuilder.InsertData(
                table: "EmerRelationshipT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mother" },
                    { 2, "Father" },
                    { 3, "Spouse" },
                    { 4, "Sibling" }
                });

            migrationBuilder.InsertData(
                table: "EmploymentStatusT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Regular" },
                    { 2, "Probationary" },
                    { 3, "Casual" },
                    { 4, "Fixed Term" },
                    { 5, "Project Based" }
                });

            migrationBuilder.InsertData(
                table: "GenderT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "InactiveStatusT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Resigned" },
                    { 3, "Terminated" },
                    { 4, "Awol" },
                    { 5, "Retired" }
                });

            migrationBuilder.InsertData(
                table: "PositionT",
                columns: new[] { "Id", "DepartmentId", "DivisionId", "Name", "Plantilla", "PosCode", "SectionId" },
                values: new object[,]
                {
                    { 1, 1, 1, "FSS", 1, "S101", 0 },
                    { 2, 1, 1, "Feeder", 9, "S102", 0 },
                    { 3, 1, 1, "FCCR", 2, "S103", 0 },
                    { 4, 4, 1, "FSS", 1, "S3K01", 0 },
                    { 5, 4, 1, "DT Booking/ GT Booking", 1, "S3K02", 0 },
                    { 6, 4, 1, "DSS", 1, "S3K03", 0 },
                    { 7, 4, 1, "PM Salesman", 1, "S3K04", 0 },
                    { 8, 4, 1, "OMNI Feeder", 3, "S3K05", 0 },
                    { 9, 4, 1, "FCCR", 1, "S3K06", 0 },
                    { 10, 5, 1, "FSS", 1, "S3C01", 0 },
                    { 11, 5, 1, "DT Booking/ GT Booking", 2, "S3C02", 0 },
                    { 12, 5, 1, "DSS", 1, "S3C03", 0 },
                    { 13, 5, 1, "OMNI Feeder", 3, "S3C04", 0 },
                    { 14, 5, 1, "FCCR", 1, "S3C05", 0 },
                    { 15, 6, 1, "Operations Manager", 1, "URIC01", 0 },
                    { 16, 6, 1, "HAPI Supervisor", 1, "URICHAP01", 4 },
                    { 17, 6, 1, "HAPI Dealer Coor", 4, "URICHAP02", 4 },
                    { 18, 6, 1, "Field Sales Supervisor", 1, "URICSER01", 5 },
                    { 19, 6, 1, "MAG Supervisor", 1, "URICSER02", 5 },
                    { 20, 6, 1, "GTAS", 5, "URICSER03", 5 },
                    { 21, 6, 1, "SMS", 11, "URICSER04", 5 },
                    { 22, 6, 1, "NAO Supervisor", 1, "URICEXP01", 6 },
                    { 23, 6, 1, "NAO", 2, "URICEXP02", 6 },
                    { 24, 6, 1, "HAPI NAO", 4, "URICEXP02", 6 },
                    { 25, 6, 1, "IT & Support Services Staff", 1, "URICDTE01", 7 },
                    { 26, 6, 1, "Teleservices Support Staff / Online Coor", 1, "URICDTE02", 7 },
                    { 27, 8, 1, "Field Sales Manager", 1, "GCASH01", 0 },
                    { 28, 8, 1, "Field Sales Supervisor", 1, "GCASH02", 0 },
                    { 29, 8, 1, "Field Sales Supervisor", 1, "GCASHSER01", 8 },
                    { 30, 8, 1, "Sonic DSP", 4, "GCASHSER02", 8 }
                });

            migrationBuilder.InsertData(
                table: "PositionT",
                columns: new[] { "Id", "DepartmentId", "DivisionId", "Name", "Plantilla", "PosCode", "SectionId" },
                values: new object[,]
                {
                    { 31, 8, 1, "DSP (Commando/Incubator)", 6, "GCASHSER03", 8 },
                    { 32, 8, 1, "Ambassador", 2, "GCASHEXP01", 9 },
                    { 33, 8, 1, "Merchandiser", 3, "GCASHMER01", 10 },
                    { 34, 8, 1, "Scan to Pay", 3, "GCASHSCA01", 11 },
                    { 35, 9, 2, "Team Leader/Supervisor", 1, "GAINV01", 12 },
                    { 36, 9, 2, "Trade Payable Staff", 2, "GAINV02", 12 },
                    { 37, 9, 2, "Non Trade Payable Staff", 1, "GAINV03", 12 },
                    { 38, 9, 2, "Team Leader/Supervisor", 1, "GAGEN01", 13 },
                    { 39, 9, 2, "Gen Accounting Staff", 3, "GAGEN02", 13 },
                    { 40, 9, 2, "Team Leader/Supervisor", 1, "GATAX01", 14 },
                    { 41, 9, 2, "Tax and Compliance Staff", 3, "GATAX02", 14 },
                    { 42, 10, 2, "Team Leader", 1, "SAACC01", 15 },
                    { 43, 10, 2, "Accounts Receivable Staff", 4, "SAACC02", 15 },
                    { 44, 10, 2, "Credit and Collection Staff", 6, "SACRE01", 16 },
                    { 45, 10, 2, "C&C - Billings to Customer", 1, "SACRE02", 16 },
                    { 46, 10, 2, "Billing to Cash Settlement Staff", 1, "SABIL01", 17 },
                    { 47, 11, 2, "Manager", 1, "IT01", 0 },
                    { 48, 11, 2, "IT Associate", 2, "IT02", 0 },
                    { 49, 11, 2, "IT Staff", 3, "IT03", 0 },
                    { 50, 12, 2, "Cash Operations Head", 1, "TREASURYCAS01", 18 },
                    { 51, 12, 2, "Davao Cashier", 3, "TREASURYCAS02", 18 },
                    { 52, 12, 2, "Cotabato Cashier", 1, "TREASURYCAS03", 18 },
                    { 53, 12, 2, "Kidapawan Cashier", 1, "TREASURYCAS04", 18 },
                    { 54, 12, 2, "Digos Cashier", 1, "TREASURYCAS05", 18 }
                });

            migrationBuilder.InsertData(
                table: "RateTypeT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Monthly Rate" },
                    { 2, "Daily Rate" }
                });

            migrationBuilder.InsertData(
                table: "ReligionT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Roman Catholic" },
                    { 2, "Iglesia ni Cristo" },
                    { 3, "Evangelicals (PCEC)" },
                    { 4, "Non-Roman Catholic" },
                    { 5, "Protestant (NCCP)" },
                    { 6, "Aglipayan" },
                    { 7, "Seventh-day Adventist" },
                    { 8, "Bible Baptist Church" },
                    { 9, "United Church of Christ in the Philippines" },
                    { 10, "Jehovah's Witnesses" },
                    { 11, "None" },
                    { 12, "Others" }
                });

            migrationBuilder.InsertData(
                table: "RestDayT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sunday" },
                    { 2, "Monday" },
                    { 3, "Tuesday" },
                    { 4, "Wednesday" }
                });

            migrationBuilder.InsertData(
                table: "RestDayT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Thursday" },
                    { 6, "Friday" },
                    { 7, "Saturday" }
                });

            migrationBuilder.InsertData(
                table: "ScheduleTypeT",
                columns: new[] { "Id", "Name", "TimeIn", "TimeOut" },
                values: new object[] { 1, "Regular", "08:00 AM", "05:00 PM" });

            migrationBuilder.InsertData(
                table: "SectionT",
                columns: new[] { "Id", "DepartmentId", "DivisionId", "Name" },
                values: new object[,]
                {
                    { 4, 6, 1, "Hapi Dealer" },
                    { 5, 6, 1, "Servicing" },
                    { 6, 6, 1, "Expansion" },
                    { 7, 6, 1, "DTEX" },
                    { 8, 8, 1, "Servicing" },
                    { 9, 8, 1, "Expansion" },
                    { 10, 8, 1, "Merchandising" },
                    { 11, 8, 1, "Scan To Pay" },
                    { 12, 9, 1, "Inventory and Accnts. Payable" },
                    { 13, 9, 1, "General Accounting" },
                    { 14, 9, 1, "Tax and Compliance" },
                    { 15, 10, 1, "Accounts Receivable" },
                    { 16, 10, 1, "Credit and Collection" },
                    { 17, 10, 1, "Billing to Cash Settlement" },
                    { 18, 12, 1, "Cash Operations" }
                });

            migrationBuilder.InsertData(
                table: "StatusT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" },
                    { 3, "Resigned" },
                    { 4, "Terminated" },
                    { 5, "Awol" },
                    { 6, "Retired" }
                });

            migrationBuilder.InsertData(
                table: "UserRoleT",
                columns: new[] { "Id", "Name", "RoleCode" },
                values: new object[,]
                {
                    { 1, "Administrator", "Admin" },
                    { 2, "User", "User" },
                    { 3, "HR", "HR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantT_App_CivilStatusId",
                table: "ApplicantT",
                column: "App_CivilStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantT_App_EmerRelationshipId",
                table: "ApplicantT",
                column: "App_EmerRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantT_App_GenderId",
                table: "ApplicantT",
                column: "App_GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantT_App_ReligionId",
                table: "ApplicantT",
                column: "App_ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditlogsT_UserId",
                table: "AuditlogsT",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentT_DepartmentId",
                table: "DocumentT",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentT_DivisionId",
                table: "DocumentT",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_PayrollT_CashbondId",
                table: "Emp_PayrollT",
                column: "CashbondId");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_PayrollT_RateTypeId",
                table: "Emp_PayrollT",
                column: "RateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_PayrollT_RestDayId",
                table: "Emp_PayrollT",
                column: "RestDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_PayrollT_ScheduleTypeId",
                table: "Emp_PayrollT",
                column: "ScheduleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_AreaId",
                table: "EmployeeT",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_CivilStatusId",
                table: "EmployeeT",
                column: "CivilStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_DepartmentId",
                table: "EmployeeT",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_DivisionId",
                table: "EmployeeT",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_EmerRelationshipId",
                table: "EmployeeT",
                column: "EmerRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_EmploymentStatusId",
                table: "EmployeeT",
                column: "EmploymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_GenderId",
                table: "EmployeeT",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_InactiveStatusId",
                table: "EmployeeT",
                column: "InactiveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_PositionId",
                table: "EmployeeT",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_ReligionId",
                table: "EmployeeT",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_StatusId",
                table: "EmployeeT",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPictureT_DepartmentId",
                table: "EmpPictureT",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPictureT_DivisionId",
                table: "EmpPictureT",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasterT_EmployeeId",
                table: "UserMasterT",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_ChildrenT");

            migrationBuilder.DropTable(
                name: "App_CollegeT");

            migrationBuilder.DropTable(
                name: "App_DoctorateT");

            migrationBuilder.DropTable(
                name: "App_LicenseT");

            migrationBuilder.DropTable(
                name: "App_MasteralT");

            migrationBuilder.DropTable(
                name: "App_OtherAwardsT");

            migrationBuilder.DropTable(
                name: "App_OtherEducT");

            migrationBuilder.DropTable(
                name: "App_PrimaryT");

            migrationBuilder.DropTable(
                name: "App_ProfBackgroundT");

            migrationBuilder.DropTable(
                name: "App_SecondaryT");

            migrationBuilder.DropTable(
                name: "App_SeniorHST");

            migrationBuilder.DropTable(
                name: "App_SiblingT");

            migrationBuilder.DropTable(
                name: "App_TrainingT");

            migrationBuilder.DropTable(
                name: "ApplicantT");

            migrationBuilder.DropTable(
                name: "AuditlogsT");

            migrationBuilder.DropTable(
                name: "DocumentT");

            migrationBuilder.DropTable(
                name: "Emp_AddressT");

            migrationBuilder.DropTable(
                name: "Emp_CollegeT");

            migrationBuilder.DropTable(
                name: "Emp_DoctorateT");

            migrationBuilder.DropTable(
                name: "Emp_EmploymentDateT");

            migrationBuilder.DropTable(
                name: "Emp_LicenseT");

            migrationBuilder.DropTable(
                name: "Emp_MasteralT");

            migrationBuilder.DropTable(
                name: "Emp_OtherEducT");

            migrationBuilder.DropTable(
                name: "Emp_PayrollT");

            migrationBuilder.DropTable(
                name: "Emp_PrimaryT");

            migrationBuilder.DropTable(
                name: "Emp_SecondaryT");

            migrationBuilder.DropTable(
                name: "Emp_SeniorHST");

            migrationBuilder.DropTable(
                name: "Emp_TrainingT");

            migrationBuilder.DropTable(
                name: "EmpPictureT");

            migrationBuilder.DropTable(
                name: "SectionT");

            migrationBuilder.DropTable(
                name: "UserRoleT");

            migrationBuilder.DropTable(
                name: "UserMasterT");

            migrationBuilder.DropTable(
                name: "CashBondT");

            migrationBuilder.DropTable(
                name: "RateTypeT");

            migrationBuilder.DropTable(
                name: "RestDayT");

            migrationBuilder.DropTable(
                name: "ScheduleTypeT");

            migrationBuilder.DropTable(
                name: "EmployeeT");

            migrationBuilder.DropTable(
                name: "AreaT");

            migrationBuilder.DropTable(
                name: "CivilStatusT");

            migrationBuilder.DropTable(
                name: "DepartmentT");

            migrationBuilder.DropTable(
                name: "DivisionT");

            migrationBuilder.DropTable(
                name: "EmerRelationshipT");

            migrationBuilder.DropTable(
                name: "EmploymentStatusT");

            migrationBuilder.DropTable(
                name: "GenderT");

            migrationBuilder.DropTable(
                name: "InactiveStatusT");

            migrationBuilder.DropTable(
                name: "PositionT");

            migrationBuilder.DropTable(
                name: "ReligionT");

            migrationBuilder.DropTable(
                name: "StatusT");
        }
    }
}
