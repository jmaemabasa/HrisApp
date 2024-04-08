using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG040820241040AM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalModifiedCountTimes",
                table: "Emp_RateHistoryT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalModifiedCountTimes",
                table: "Emp_RateHistoryT",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
