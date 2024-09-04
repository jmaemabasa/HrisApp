using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG090320240511 : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "SubPositionT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubPositionT_PositionId",
                table: "SubPositionT",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubPositionT_PositionT_PositionId",
                table: "SubPositionT",
                column: "PositionId",
                principalTable: "PositionT",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubPositionT_PositionT_PositionId",
                table: "SubPositionT");

            migrationBuilder.DropIndex(
                name: "IX_SubPositionT_PositionId",
                table: "SubPositionT");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "SubPositionT");
        }
    }
}
