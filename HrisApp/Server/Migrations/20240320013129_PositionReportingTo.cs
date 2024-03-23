using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class PositionReportingTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.AddColumn<string>(
                name: "ReportingTo",
                table: "SubPositionT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportingTo",
                table: "SubPositionT");

            migrationBuilder.InsertData(
                table: "PositionT",
                columns: new[] { "Id", "AreaId", "DepartmentId", "DivisionId", "JobSummary", "Manpower", "Name", "OtherCompetencies", "Plantilla", "PosCode", "PosEducation", "PosMPExternalId", "PositionType", "Restrictions", "SectionId", "TemporaryDuration", "VerifyId", "WorkExperience" },
                values: new object[] { 44, 1, 10, 2, "", "Internal", "Credit and Collection Staff", "", 6, "SACRE01", "", 0, "", "", 16, "", "", "" });

            migrationBuilder.InsertData(
                table: "PositionT",
                columns: new[] { "Id", "AreaId", "DepartmentId", "DivisionId", "JobSummary", "Manpower", "Name", "OtherCompetencies", "Plantilla", "PosCode", "PosEducation", "PosMPExternalId", "PositionType", "Restrictions", "SectionId", "TemporaryDuration", "VerifyId", "WorkExperience" },
                values: new object[] { 45, 1, 10, 2, "", "Internal", "C&C - Billings to Customer", "", 1, "SACRE02", "", 0, "", "", 16, "", "", "" });
        }
    }
}
