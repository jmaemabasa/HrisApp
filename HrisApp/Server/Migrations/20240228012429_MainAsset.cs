using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MainAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    App_DateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    App_DateTo = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "App_SelfDeclarationT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q1Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q1Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q2Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q2Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q3Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q3Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q4Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q4Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q5Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q5Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q6Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q6Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q7Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q7Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q8Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q8Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_SelfDeclarationT", x => x.Id);
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
                name: "AssetCategoryT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACat_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACat_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCategoryT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetStatusT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStatusT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetTypesT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AType_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AType_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypesT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceRecordT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AC_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRecordT", x => x.Id);
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
                name: "DailyTotalPlantillaT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPlantilla = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTotalPlantillaT", x => x.Id);
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
                name: "Emp_EvaluationT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eval1Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eval2Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eval3Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eval4Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eval5Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eval6Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateHired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEvaluate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimesEvaluate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_EvaluationT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_LeaveCreditT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EL = table.Column<int>(type: "int", nullable: false),
                    ML = table.Column<int>(type: "int", nullable: false),
                    PL = table.Column<int>(type: "int", nullable: false),
                    SL = table.Column<int>(type: "int", nullable: false),
                    VL = table.Column<int>(type: "int", nullable: false),
                    OL = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_LeaveCreditT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emp_LeaveHistoryT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: true),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoOfDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReadStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_LeaveHistoryT", x => x.Id);
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
                name: "Emp_PosHistoryT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    NewAreaId = table.Column<int>(type: "int", nullable: false),
                    NewDivisionId = table.Column<int>(type: "int", nullable: false),
                    NewDepartmentId = table.Column<int>(type: "int", nullable: false),
                    NewSectionId = table.Column<int>(type: "int", nullable: false),
                    NewPositionId = table.Column<int>(type: "int", nullable: false),
                    newPositionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_PosHistoryT", x => x.Id);
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
                name: "LeaveTypesT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypesT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionComAppT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionComAppT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionEducT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionEducT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionKnowledgeT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KnowName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionKnowledgeT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    JobSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosEducation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherCompetencies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Restrictions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plantilla = table.Column<int>(type: "int", nullable: false),
                    PositionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemporaryDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manpower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosMPExternalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionTechSkillT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionTechSkillT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionWorkExpT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionWorkExpT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PosMPExternalT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    External_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    External_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosMPExternalT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PosMPInternalT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Internal_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Internal_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosMPInternalT", x => x.Id);
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
                name: "ShiftTimetableT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timetable_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnDuty_Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    OffDuty_Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Begin_C_In = table.Column<TimeSpan>(type: "time", nullable: false),
                    Ending_C_In = table.Column<TimeSpan>(type: "time", nullable: false),
                    Begin_C_Out = table.Column<TimeSpan>(type: "time", nullable: false),
                    Ending_C_Out = table.Column<TimeSpan>(type: "time", nullable: false),
                    Workday_Count = table.Column<int>(type: "int", nullable: false),
                    Minute_Count = table.Column<int>(type: "int", nullable: false),
                    Late_Time = table.Column<int>(type: "int", nullable: false),
                    LeaveEarly_Time = table.Column<int>(type: "int", nullable: false),
                    Must_C_In = table.Column<bool>(type: "bit", nullable: false),
                    Must_C_Out = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTimetableT", x => x.Id);
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
                name: "SubPositionT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubPosCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emp_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPositionT", x => x.Id);
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
                name: "AssetSubCategoryT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ASubCat_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ASubCat_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetSubCategoryT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetSubCategoryT_AssetCategoryT_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DocumentT_DivisionT_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "DivisionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmpPictureT_DivisionT_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "DivisionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_PosApplied1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_PosApplied2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_PresSalary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_ExpSalary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_SourceApp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateApplied = table.Column<DateTime>(type: "datetime2", nullable: false),
                    App_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_Suffix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApplicantT_EmerRelationshipT_App_EmerRelationshipId",
                        column: x => x.App_EmerRelationshipId,
                        principalTable: "EmerRelationshipT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApplicantT_GenderT_App_GenderId",
                        column: x => x.App_GenderId,
                        principalTable: "GenderT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ApplicantT_ReligionT_App_ReligionId",
                        column: x => x.App_ReligionId,
                        principalTable: "ReligionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Emp_PayrollT_RateTypeT_RateTypeId",
                        column: x => x.RateTypeId,
                        principalTable: "RateTypeT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Emp_PayrollT_RestDayT_RestDayId",
                        column: x => x.RestDayId,
                        principalTable: "RestDayT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Emp_PayrollT_ScheduleTypeT_ScheduleTypeId",
                        column: x => x.ScheduleTypeId,
                        principalTable: "ScheduleTypeT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ann_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ann_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ann_Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementT_StatusT_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeT_AreaT_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AreaT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeT_CivilStatusT_CivilStatusId",
                        column: x => x.CivilStatusId,
                        principalTable: "CivilStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeT_DepartmentT_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeT_DivisionT_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "DivisionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeT_EmerRelationshipT_EmerRelationshipId",
                        column: x => x.EmerRelationshipId,
                        principalTable: "EmerRelationshipT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeT_EmploymentStatusT_EmploymentStatusId",
                        column: x => x.EmploymentStatusId,
                        principalTable: "EmploymentStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeT_GenderT_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GenderT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeT_ReligionT_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "ReligionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeT_StatusT_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AssetMasterT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorksationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchaseAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EUF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssetStatusId = table.Column<int>(type: "int", nullable: false),
                    InUseStatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssetNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsernameAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastCheckDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMasterT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetMasterT_AreaT_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AreaT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetMasterT_AssetCategoryT_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetMasterT_AssetStatusT_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetMasterT_AssetSubCategoryT_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "AssetSubCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetMasterT_AssetTypesT_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AssetTypesT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetMasterT_EmployeeT_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuditlogsT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeUserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditlogsT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditlogsT_EmployeeT_EmployeeUserId",
                        column: x => x.EmployeeUserId,
                        principalTable: "EmployeeT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserMasterT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Emp_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AssetAccessoryT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    AssetStatusId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUseStatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EUF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MainAssetId = table.Column<int>(type: "int", nullable: true),
                    MainAssetDateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAccessoryT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetAccessoryT_AssetCategoryT_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetAccessoryT_AssetMasterT_MainAssetId",
                        column: x => x.MainAssetId,
                        principalTable: "AssetMasterT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssetAccessoryT_AssetStatusT_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetAccessoryT_AssetSubCategoryT_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "AssetSubCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetAccessoryT_AssetTypesT_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AssetTypesT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MainAssetAccessoriesT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetMasterId = table.Column<int>(type: "int", nullable: false),
                    AssetMasterCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetAccessoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    DateUsed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateStatusChanged = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainAssetAccessoriesT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainAssetAccessoriesT_AssetAccessoryT_AssetAccessoryId",
                        column: x => x.AssetAccessoryId,
                        principalTable: "AssetAccessoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MainAssetAccessoriesT_AssetCategoryT_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MainAssetAccessoriesT_AssetMasterT_AssetMasterId",
                        column: x => x.AssetMasterId,
                        principalTable: "AssetMasterT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MainAssetAccessoriesT_AssetSubCategoryT_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "AssetSubCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                table: "AssetStatusT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IN USED" },
                    { 2, "NOT USED" },
                    { 3, "FOR REPAIR" },
                    { 4, "IN SERVICE CENTER" },
                    { 5, "FOR DISPOSAL" },
                    { 6, "DISPOSED" }
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
                    { 3, "Supply Chain Management Service" }
                });

            migrationBuilder.InsertData(
                table: "DivisionT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
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
                table: "LeaveTypesT",
                columns: new[] { "Id", "Code", "Description", "Name", "Unit" },
                values: new object[,]
                {
                    { 1, "EL", "Day", "Emergency", 1.0 },
                    { 2, "ML", "Day", "Maternity", 1.0 },
                    { 3, "PL", "Day", "Paternity", 1.0 },
                    { 4, "SL", "Day", "Sick", 1.0 },
                    { 5, "VL", "Day", "Vacation", 1.0 },
                    { 6, "OL", "Day", "Other", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "PositionT",
                columns: new[] { "Id", "AreaId", "DepartmentId", "DivisionId", "JobSummary", "Manpower", "Name", "OtherCompetencies", "Plantilla", "PosCode", "PosEducation", "PosMPExternalId", "PositionType", "Restrictions", "SectionId", "TemporaryDuration", "VerifyId", "WorkExperience" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "", "Internal", "FSS", "", 1, "S101", "", 0, "", "", 0, "", "", "" },
                    { 2, 1, 1, 1, "", "Internal", "Feeder", "", 2, "S102", "", 0, "", "", 0, "", "", "" },
                    { 3, 1, 1, 1, "", "Internal", "FCCR", "", 2, "S103", "", 0, "", "", 0, "", "", "" },
                    { 4, 1, 4, 1, "", "Internal", "FSS", "", 1, "S3K01", "", 0, "", "", 0, "", "", "" },
                    { 5, 1, 4, 1, "", "Internal", "DT Booking/ GT Booking", "", 1, "S3K02", "", 0, "", "", 0, "", "", "" },
                    { 6, 1, 4, 1, "", "Internal", "DSS", "", 1, "S3K03", "", 0, "", "", 0, "", "", "" },
                    { 7, 1, 4, 1, "", "Internal", "PM Salesman", "", 1, "S3K04", "", 0, "", "", 0, "", "", "" },
                    { 8, 1, 4, 1, "", "Internal", "OMNI Feeder", "", 3, "S3K05", "", 0, "", "", 0, "", "", "" },
                    { 9, 1, 4, 1, "", "Internal", "FCCR", "", 1, "S3K06", "", 0, "", "", 0, "", "", "" },
                    { 10, 1, 5, 1, "", "Internal", "FSS", "", 1, "S3C01", "", 0, "", "", 0, "", "", "" },
                    { 11, 1, 5, 1, "", "Internal", "DT Booking/ GT Booking", "", 2, "S3C02", "", 0, "", "", 0, "", "", "" },
                    { 12, 1, 5, 1, "", "Internal", "DSS", "", 1, "S3C03", "", 0, "", "", 0, "", "", "" },
                    { 13, 1, 5, 1, "", "Internal", "OMNI Feeder", "", 3, "S3C04", "", 0, "", "", 0, "", "", "" },
                    { 14, 1, 5, 1, "", "Internal", "FCCR", "", 1, "S3C05", "", 0, "", "", 0, "", "", "" },
                    { 15, 1, 6, 1, "", "Internal", "Operations Manager", "", 1, "URIC01", "", 0, "", "", 0, "", "", "" },
                    { 16, 1, 6, 1, "", "Internal", "HAPI Supervisor", "", 1, "URICHAP01", "", 0, "", "", 4, "", "", "" },
                    { 17, 1, 6, 1, "", "Internal", "HAPI Dealer Coor", "", 4, "URICHAP02", "", 0, "", "", 4, "", "", "" },
                    { 18, 1, 6, 1, "", "Internal", "Field Sales Supervisor", "", 1, "URICSER01", "", 0, "", "", 5, "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "PositionT",
                columns: new[] { "Id", "AreaId", "DepartmentId", "DivisionId", "JobSummary", "Manpower", "Name", "OtherCompetencies", "Plantilla", "PosCode", "PosEducation", "PosMPExternalId", "PositionType", "Restrictions", "SectionId", "TemporaryDuration", "VerifyId", "WorkExperience" },
                values: new object[,]
                {
                    { 19, 1, 6, 1, "", "Internal", "MAG Supervisor", "", 1, "URICSER02", "", 0, "", "", 5, "", "", "" },
                    { 20, 1, 6, 1, "", "Internal", "GTAS", "", 5, "URICSER03", "", 0, "", "", 5, "", "", "" },
                    { 21, 1, 6, 1, "", "Internal", "SMS", "", 11, "URICSER04", "", 0, "", "", 5, "", "", "" },
                    { 22, 1, 6, 1, "", "Internal", "NAO Supervisor", "", 1, "URICEXP01", "", 0, "", "", 6, "", "", "" },
                    { 23, 1, 6, 1, "", "Internal", "NAO", "", 2, "URICEXP02", "", 0, "", "", 6, "", "", "" },
                    { 24, 1, 6, 1, "", "Internal", "HAPI NAO", "", 4, "URICEXP02", "", 0, "", "", 6, "", "", "" },
                    { 25, 1, 6, 1, "", "Internal", "IT & Support Services Staff", "", 1, "URICDTE01", "", 0, "", "", 7, "", "", "" },
                    { 26, 1, 6, 1, "", "Internal", "Teleservices Support Staff / Online Coor", "", 1, "URICDTE02", "", 0, "", "", 7, "", "", "" },
                    { 27, 1, 8, 1, "", "Internal", "Field Sales Manager", "", 1, "GCASH01", "", 0, "", "", 0, "", "", "" },
                    { 28, 1, 8, 1, "", "Internal", "Field Sales Supervisor", "", 1, "GCASH02", "", 0, "", "", 0, "", "", "" },
                    { 29, 1, 8, 1, "", "Internal", "Field Sales Supervisor", "", 1, "GCASHSER01", "", 0, "", "", 8, "", "", "" },
                    { 30, 1, 8, 1, "", "Internal", "Sonic DSP", "", 4, "GCASHSER02", "", 0, "", "", 8, "", "", "" },
                    { 31, 1, 8, 1, "", "Internal", "DSP (Commando/Incubator)", "", 6, "GCASHSER03", "", 0, "", "", 8, "", "", "" },
                    { 32, 1, 8, 1, "", "Internal", "Ambassador", "", 2, "GCASHEXP01", "", 0, "", "", 9, "", "", "" },
                    { 33, 1, 8, 1, "", "Internal", "Merchandiser", "", 3, "GCASHMER01", "", 0, "", "", 10, "", "", "" },
                    { 34, 1, 8, 1, "", "Internal", "Scan to Pay", "", 3, "GCASHSCA01", "", 0, "", "", 11, "", "", "" },
                    { 35, 1, 9, 2, "", "Internal", "Team Leader/Supervisor", "", 1, "GAINV01", "", 0, "", "", 12, "", "", "" },
                    { 36, 1, 9, 2, "", "Internal", "Trade Payable Staff", "", 2, "GAINV02", "", 0, "", "", 12, "", "", "" },
                    { 37, 1, 9, 2, "", "Internal", "Non Trade Payable Staff", "", 1, "GAINV03", "", 0, "", "", 12, "", "", "" },
                    { 38, 1, 9, 2, "", "Internal", "Team Leader/Supervisor", "", 1, "GAGEN01", "", 0, "", "", 13, "", "", "" },
                    { 39, 1, 9, 2, "", "Internal", "Gen Accounting Staff", "", 3, "GAGEN02", "", 0, "", "", 13, "", "", "" },
                    { 40, 1, 9, 2, "", "Internal", "Team Leader/Supervisor", "", 1, "GATAX01", "", 0, "", "", 14, "", "", "" },
                    { 41, 1, 9, 2, "", "Internal", "Tax and Compliance Staff", "", 3, "GATAX02", "", 0, "", "", 14, "", "", "" },
                    { 42, 1, 10, 2, "", "Internal", "Team Leader", "", 1, "SAACC01", "", 0, "", "", 15, "", "", "" },
                    { 43, 1, 10, 2, "", "Internal", "Accounts Receivable Staff", "", 4, "SAACC02", "", 0, "", "", 15, "", "", "" },
                    { 44, 1, 10, 2, "", "Internal", "Credit and Collection Staff", "", 6, "SACRE01", "", 0, "", "", 16, "", "", "" },
                    { 45, 1, 10, 2, "", "Internal", "C&C - Billings to Customer", "", 1, "SACRE02", "", 0, "", "", 16, "", "", "" },
                    { 46, 1, 10, 2, "", "Internal", "Billing to Cash Settlement Staff", "", 1, "SABIL01", "", 0, "", "", 17, "", "", "" },
                    { 47, 1, 11, 2, "", "Internal", "Manager", "", 1, "IT01", "", 0, "", "", 0, "", "", "" },
                    { 48, 1, 11, 2, "", "Internal", "IT Associate", "", 2, "IT02", "", 0, "", "", 0, "", "", "" },
                    { 49, 1, 11, 2, "", "Internal", "IT Staff", "", 3, "IT03", "", 0, "", "", 0, "", "", "" },
                    { 50, 1, 12, 2, "", "Internal", "Cash Operations Head", "", 1, "TREASURYCAS01", "", 0, "", "", 18, "", "", "" },
                    { 51, 1, 12, 2, "", "Internal", "Davao Cashier", "", 3, "TREASURYCAS02", "", 0, "", "", 18, "", "", "" },
                    { 52, 1, 12, 2, "", "Internal", "Cotabato Cashier", "", 1, "TREASURYCAS03", "", 0, "", "", 18, "", "", "" },
                    { 53, 1, 12, 2, "", "Internal", "Kidapawan Cashier", "", 1, "TREASURYCAS04", "", 0, "", "", 18, "", "", "" },
                    { 54, 1, 12, 2, "", "Internal", "Digos Cashier", "", 1, "TREASURYCAS05", "", 0, "", "", 18, "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "RateTypeT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Monthly" },
                    { 2, "Daily" },
                    { 3, "Hourly" }
                });

            migrationBuilder.InsertData(
                table: "ReligionT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Roman Catholic" },
                    { 2, "Iglesia ni Cristo" },
                    { 3, "Evangelicals (PCEC)" }
                });

            migrationBuilder.InsertData(
                table: "ReligionT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
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
                    { 4, "Wednesday" },
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
                    { 1, "System Administrator", "Admin" },
                    { 2, "User", "User" },
                    { 3, "HR", "HR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementT_StatusId",
                table: "AnnouncementT",
                column: "StatusId");

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
                name: "IX_AssetAccessoryT_AssetStatusId",
                table: "AssetAccessoryT",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoryT_CategoryId",
                table: "AssetAccessoryT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoryT_MainAssetId",
                table: "AssetAccessoryT",
                column: "MainAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoryT_SubCategoryId",
                table: "AssetAccessoryT",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoryT_TypeId",
                table: "AssetAccessoryT",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_AreaId",
                table: "AssetMasterT",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_AssetStatusId",
                table: "AssetMasterT",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_CategoryId",
                table: "AssetMasterT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_EmployeeId",
                table: "AssetMasterT",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_SubCategoryId",
                table: "AssetMasterT",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_TypeId",
                table: "AssetMasterT",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetSubCategoryT_CategoryId",
                table: "AssetSubCategoryT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditlogsT_EmployeeUserId",
                table: "AuditlogsT",
                column: "EmployeeUserId");

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
                name: "IX_MainAssetAccessoriesT_AssetAccessoryId",
                table: "MainAssetAccessoriesT",
                column: "AssetAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetAccessoriesT_AssetMasterId",
                table: "MainAssetAccessoriesT",
                column: "AssetMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetAccessoriesT_CategoryId",
                table: "MainAssetAccessoriesT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetAccessoriesT_SubCategoryId",
                table: "MainAssetAccessoriesT",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasterT_EmployeeId",
                table: "UserMasterT",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementT");

            migrationBuilder.DropTable(
                name: "App_AddressT");

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
                name: "App_SelfDeclarationT");

            migrationBuilder.DropTable(
                name: "App_SeniorHST");

            migrationBuilder.DropTable(
                name: "App_SiblingT");

            migrationBuilder.DropTable(
                name: "App_TrainingT");

            migrationBuilder.DropTable(
                name: "ApplicantT");

            migrationBuilder.DropTable(
                name: "AttendanceRecordT");

            migrationBuilder.DropTable(
                name: "AuditlogsT");

            migrationBuilder.DropTable(
                name: "DailyTotalPlantillaT");

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
                name: "Emp_EvaluationT");

            migrationBuilder.DropTable(
                name: "Emp_LeaveCreditT");

            migrationBuilder.DropTable(
                name: "Emp_LeaveHistoryT");

            migrationBuilder.DropTable(
                name: "Emp_LicenseT");

            migrationBuilder.DropTable(
                name: "Emp_MasteralT");

            migrationBuilder.DropTable(
                name: "Emp_OtherEducT");

            migrationBuilder.DropTable(
                name: "Emp_PayrollT");

            migrationBuilder.DropTable(
                name: "Emp_PosHistoryT");

            migrationBuilder.DropTable(
                name: "Emp_PrimaryT");

            migrationBuilder.DropTable(
                name: "Emp_ProfBackgroundT");

            migrationBuilder.DropTable(
                name: "Emp_SecondaryT");

            migrationBuilder.DropTable(
                name: "Emp_SeniorHST");

            migrationBuilder.DropTable(
                name: "Emp_TrainingT");

            migrationBuilder.DropTable(
                name: "EmpPictureT");

            migrationBuilder.DropTable(
                name: "InactiveStatusT");

            migrationBuilder.DropTable(
                name: "LeaveTypesT");

            migrationBuilder.DropTable(
                name: "MainAssetAccessoriesT");

            migrationBuilder.DropTable(
                name: "PositionComAppT");

            migrationBuilder.DropTable(
                name: "PositionEducT");

            migrationBuilder.DropTable(
                name: "PositionKnowledgeT");

            migrationBuilder.DropTable(
                name: "PositionT");

            migrationBuilder.DropTable(
                name: "PositionTechSkillT");

            migrationBuilder.DropTable(
                name: "PositionWorkExpT");

            migrationBuilder.DropTable(
                name: "PosMPExternalT");

            migrationBuilder.DropTable(
                name: "PosMPInternalT");

            migrationBuilder.DropTable(
                name: "SectionT");

            migrationBuilder.DropTable(
                name: "ShiftTimetableT");

            migrationBuilder.DropTable(
                name: "SubPositionT");

            migrationBuilder.DropTable(
                name: "UserMasterT");

            migrationBuilder.DropTable(
                name: "UserRoleT");

            migrationBuilder.DropTable(
                name: "CashBondT");

            migrationBuilder.DropTable(
                name: "RateTypeT");

            migrationBuilder.DropTable(
                name: "RestDayT");

            migrationBuilder.DropTable(
                name: "ScheduleTypeT");

            migrationBuilder.DropTable(
                name: "AssetAccessoryT");

            migrationBuilder.DropTable(
                name: "AssetMasterT");

            migrationBuilder.DropTable(
                name: "AssetStatusT");

            migrationBuilder.DropTable(
                name: "AssetSubCategoryT");

            migrationBuilder.DropTable(
                name: "AssetTypesT");

            migrationBuilder.DropTable(
                name: "EmployeeT");

            migrationBuilder.DropTable(
                name: "AssetCategoryT");

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
                name: "ReligionT");

            migrationBuilder.DropTable(
                name: "StatusT");
        }
    }
}
