using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class eval4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeVerifyId",
                table: "EmployeeEvaluationT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Eval1Status",
                table: "EmployeeEvaluationT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Eval2Status",
                table: "EmployeeEvaluationT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Eval3Status",
                table: "EmployeeEvaluationT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Eval4Status",
                table: "EmployeeEvaluationT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Eval5Status",
                table: "EmployeeEvaluationT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Eval6Status",
                table: "EmployeeEvaluationT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EvalStatus",
                table: "EmployeeEvaluationT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluationT_EmployeeId",
                table: "EmployeeEvaluationT",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEvaluationT_EmployeeT_EmployeeId",
                table: "EmployeeEvaluationT",
                column: "EmployeeId",
                principalTable: "EmployeeT",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEvaluationT_EmployeeT_EmployeeId",
                table: "EmployeeEvaluationT");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeEvaluationT_EmployeeId",
                table: "EmployeeEvaluationT");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeEvaluationT");

            migrationBuilder.DropColumn(
                name: "EmployeeVerifyId",
                table: "EmployeeEvaluationT");

            migrationBuilder.DropColumn(
                name: "Eval1Status",
                table: "EmployeeEvaluationT");

            migrationBuilder.DropColumn(
                name: "Eval2Status",
                table: "EmployeeEvaluationT");

            migrationBuilder.DropColumn(
                name: "Eval3Status",
                table: "EmployeeEvaluationT");

            migrationBuilder.DropColumn(
                name: "Eval4Status",
                table: "EmployeeEvaluationT");

            migrationBuilder.DropColumn(
                name: "Eval5Status",
                table: "EmployeeEvaluationT");

            migrationBuilder.DropColumn(
                name: "Eval6Status",
                table: "EmployeeEvaluationT");

            migrationBuilder.DropColumn(
                name: "EvalStatus",
                table: "EmployeeEvaluationT");
        }
    }
}
