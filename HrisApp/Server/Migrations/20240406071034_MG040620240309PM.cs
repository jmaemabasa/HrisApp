using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG040620240309PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verify_Id",
                table: "Emp_RateHistoryT");

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectivityDate",
                table: "Emp_RateHistoryT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EffEndDate",
                table: "Emp_RateHistoryT",
                type: "datetime2",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EffectivityDate",
                table: "Emp_RateHistoryT");

            migrationBuilder.DropColumn(
                name: "EffEndDate",
                table: "Emp_RateHistoryT");
        }
    }
}
