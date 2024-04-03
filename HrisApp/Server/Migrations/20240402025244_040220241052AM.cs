using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class _040220241052AM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmploymentStatusId",
                table: "Emp_PosHistoryT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emp_PosHistoryT_EmploymentStatusId",
                table: "Emp_PosHistoryT",
                column: "EmploymentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emp_PosHistoryT_EmploymentStatusT_EmploymentStatusId",
                table: "Emp_PosHistoryT",
                column: "EmploymentStatusId",
                principalTable: "EmploymentStatusT",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emp_PosHistoryT_EmploymentStatusT_EmploymentStatusId",
                table: "Emp_PosHistoryT");

            migrationBuilder.DropIndex(
                name: "IX_Emp_PosHistoryT_EmploymentStatusId",
                table: "Emp_PosHistoryT");

            migrationBuilder.DropColumn(
                name: "EmploymentStatusId",
                table: "Emp_PosHistoryT");

            migrationBuilder.AddColumn<string>(
                name: "Eval4Status",
                table: "Emp_EvaluationT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Eval6Status",
                table: "Emp_EvaluationT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
