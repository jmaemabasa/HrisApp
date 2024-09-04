using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG090320240426 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "SubPositionId",
                table: "EmployeeT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_SubPositionId",
                table: "EmployeeT",
                column: "SubPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeT_SubPositionT_SubPositionId",
                table: "EmployeeT",
                column: "SubPositionId",
                principalTable: "SubPositionT",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeT_SubPositionT_SubPositionId",
                table: "EmployeeT");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeT_SubPositionId",
                table: "EmployeeT");

            migrationBuilder.DropColumn(
                name: "SubPositionId",
                table: "EmployeeT");
        }
    }
}
