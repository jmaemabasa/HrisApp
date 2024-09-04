using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG0904202409103 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeT_SubPositionT_SubPositionId",
                table: "EmployeeT");

            migrationBuilder.AlterColumn<int>(
                name: "SubPositionId",
                table: "EmployeeT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeT_SubPositionT_SubPositionId",
                table: "EmployeeT",
                column: "SubPositionId",
                principalTable: "SubPositionT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeT_SubPositionT_SubPositionId",
                table: "EmployeeT");

            migrationBuilder.AlterColumn<int>(
                name: "SubPositionId",
                table: "EmployeeT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeT_SubPositionT_SubPositionId",
                table: "EmployeeT",
                column: "SubPositionId",
                principalTable: "SubPositionT",
                principalColumn: "Id");
        }
    }
}
