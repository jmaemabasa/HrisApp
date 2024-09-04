using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG090420240926 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubPositionT_PositionT_PositionId",
                table: "SubPositionT");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "SubPositionT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubPositionT_PositionT_PositionId",
                table: "SubPositionT",
                column: "PositionId",
                principalTable: "PositionT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubPositionT_PositionT_PositionId",
                table: "SubPositionT");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "SubPositionT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SubPositionT_PositionT_PositionId",
                table: "SubPositionT",
                column: "PositionId",
                principalTable: "PositionT",
                principalColumn: "Id");
        }
    }
}
