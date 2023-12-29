using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class leavehistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Left_EL",
                table: "Emp_LeaveCreditT");

            migrationBuilder.DropColumn(
                name: "Left_ML",
                table: "Emp_LeaveCreditT");

            migrationBuilder.DropColumn(
                name: "Left_OL",
                table: "Emp_LeaveCreditT");

            migrationBuilder.DropColumn(
                name: "Left_PL",
                table: "Emp_LeaveCreditT");

            migrationBuilder.DropColumn(
                name: "Left_SL",
                table: "Emp_LeaveCreditT");

            migrationBuilder.DropColumn(
                name: "Left_VL",
                table: "Emp_LeaveCreditT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Left_EL",
                table: "Emp_LeaveCreditT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Left_ML",
                table: "Emp_LeaveCreditT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Left_OL",
                table: "Emp_LeaveCreditT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Left_PL",
                table: "Emp_LeaveCreditT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Left_SL",
                table: "Emp_LeaveCreditT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Left_VL",
                table: "Emp_LeaveCreditT",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
