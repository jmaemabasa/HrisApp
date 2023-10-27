using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Restday",
                table: "PayrollT");

            migrationBuilder.AddColumn<int>(
                name: "RestDayId",
                table: "PayrollT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PayrollT_RestDayId",
                table: "PayrollT",
                column: "RestDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollT_RestDayT_RestDayId",
                table: "PayrollT",
                column: "RestDayId",
                principalTable: "RestDayT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrollT_RestDayT_RestDayId",
                table: "PayrollT");

            migrationBuilder.DropIndex(
                name: "IX_PayrollT_RestDayId",
                table: "PayrollT");

            migrationBuilder.DropColumn(
                name: "RestDayId",
                table: "PayrollT");

            migrationBuilder.AddColumn<string>(
                name: "Restday",
                table: "PayrollT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
