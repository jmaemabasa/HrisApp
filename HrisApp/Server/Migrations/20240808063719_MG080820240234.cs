using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG080820240234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_PositionT_AreaId",
                table: "PositionT",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionT_DepartmentId",
                table: "PositionT",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionT_DivisionId",
                table: "PositionT",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionT_AreaT_AreaId",
                table: "PositionT",
                column: "AreaId",
                principalTable: "AreaT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionT_DepartmentT_DepartmentId",
                table: "PositionT",
                column: "DepartmentId",
                principalTable: "DepartmentT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionT_DivisionT_DivisionId",
                table: "PositionT",
                column: "DivisionId",
                principalTable: "DivisionT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionT_AreaT_AreaId",
                table: "PositionT");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionT_DepartmentT_DepartmentId",
                table: "PositionT");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionT_DivisionT_DivisionId",
                table: "PositionT");

            migrationBuilder.DropIndex(
                name: "IX_PositionT_AreaId",
                table: "PositionT");

            migrationBuilder.DropIndex(
                name: "IX_PositionT_DepartmentId",
                table: "PositionT");

            migrationBuilder.DropIndex(
                name: "IX_PositionT_DivisionId",
                table: "PositionT");
        }
    }
}
