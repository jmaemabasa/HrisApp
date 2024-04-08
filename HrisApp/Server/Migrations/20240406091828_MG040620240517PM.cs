using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG040620240517PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Emp_RateHistoryT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emp_RateHistoryT_PositionId",
                table: "Emp_RateHistoryT",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emp_RateHistoryT_SubPositionT_PositionId",
                table: "Emp_RateHistoryT",
                column: "PositionId",
                principalTable: "SubPositionT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emp_RateHistoryT_SubPositionT_PositionId",
                table: "Emp_RateHistoryT");

            migrationBuilder.DropIndex(
                name: "IX_Emp_RateHistoryT_PositionId",
                table: "Emp_RateHistoryT");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Emp_RateHistoryT");
        }
    }
}
