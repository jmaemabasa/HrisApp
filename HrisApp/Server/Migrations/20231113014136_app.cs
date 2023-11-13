using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class app : Migration
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
                name: "ApplicantT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_Suffix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_ContactNo1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    App_ContactNo2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantT_App_CivilStatusId",
                table: "ApplicantT",
                column: "App_CivilStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantT_App_GenderId",
                table: "ApplicantT",
                column: "App_GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantT_App_ReligionId",
                table: "ApplicantT",
                column: "App_ReligionId");
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
        }
    }
}
