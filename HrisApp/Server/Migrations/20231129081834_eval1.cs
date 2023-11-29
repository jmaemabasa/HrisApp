using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class eval1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEvaluationT_EmployeeT_EmployeeId",
                table: "EmployeeEvaluationT");

            migrationBuilder.RenameColumn(
                name: "Verify_Id",
                table: "EmployeeEvaluationT",
                newName: "EmployeeVerify_Id");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeEvaluationT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.RenameColumn(
                name: "EmployeeVerify_Id",
                table: "EmployeeEvaluationT",
                newName: "Verify_Id");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeEvaluationT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEvaluationT_EmployeeT_EmployeeId",
                table: "EmployeeEvaluationT",
                column: "EmployeeId",
                principalTable: "EmployeeT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
