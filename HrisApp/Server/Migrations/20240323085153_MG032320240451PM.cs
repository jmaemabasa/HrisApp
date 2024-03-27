using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG032320240451PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UOMId",
                table: "ConsumablesT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesT_UOMId",
                table: "ConsumablesT",
                column: "UOMId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumablesT_UOMT_UOMId",
                table: "ConsumablesT",
                column: "UOMId",
                principalTable: "UOMT",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsumablesT_UOMT_UOMId",
                table: "ConsumablesT");

            migrationBuilder.DropIndex(
                name: "IX_ConsumablesT_UOMId",
                table: "ConsumablesT");

            migrationBuilder.DropColumn(
                name: "UOMId",
                table: "ConsumablesT");
        }
    }
}
