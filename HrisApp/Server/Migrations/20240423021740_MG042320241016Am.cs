using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG042320241016Am : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeT_ReligionT_ReligionId",
                table: "EmployeeT");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeT_ReligionId",
                table: "EmployeeT");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "EmployeeT");

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "EmployeeT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Religion",
                table: "EmployeeT");

            migrationBuilder.AddColumn<int>(
                name: "ReligionId",
                table: "EmployeeT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_ReligionId",
                table: "EmployeeT",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeT_ReligionT_ReligionId",
                table: "EmployeeT",
                column: "ReligionId",
                principalTable: "ReligionT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
