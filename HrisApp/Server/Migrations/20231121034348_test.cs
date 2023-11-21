using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeT_InactiveStatusT_InactiveStatusId",
                table: "EmployeeT");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeT_InactiveStatusId",
                table: "EmployeeT");

            migrationBuilder.DropColumn(
                name: "InactiveStatusId",
                table: "EmployeeT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InactiveStatusId",
                table: "EmployeeT",
                type: "int",
                nullable: false,
                defaultValue: 0);

           

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_InactiveStatusId",
                table: "EmployeeT",
                column: "InactiveStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeT_InactiveStatusT_InactiveStatusId",
                table: "EmployeeT",
                column: "InactiveStatusId",
                principalTable: "InactiveStatusT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
