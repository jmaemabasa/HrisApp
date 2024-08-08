using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG08082024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SubPositionT_AreaId",
                table: "SubPositionT",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubPositionT_DepartmentId",
                table: "SubPositionT",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubPositionT_DivisionId",
                table: "SubPositionT",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubPositionT_AreaT_AreaId",
                table: "SubPositionT",
                column: "AreaId",
                principalTable: "AreaT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SubPositionT_DepartmentT_DepartmentId",
                table: "SubPositionT",
                column: "DepartmentId",
                principalTable: "DepartmentT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SubPositionT_DivisionT_DivisionId",
                table: "SubPositionT",
                column: "DivisionId",
                principalTable: "DivisionT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubPositionT_AreaT_AreaId",
                table: "SubPositionT");

            migrationBuilder.DropForeignKey(
                name: "FK_SubPositionT_DepartmentT_DepartmentId",
                table: "SubPositionT");

            migrationBuilder.DropForeignKey(
                name: "FK_SubPositionT_DivisionT_DivisionId",
                table: "SubPositionT");

            migrationBuilder.DropIndex(
                name: "IX_SubPositionT_AreaId",
                table: "SubPositionT");

            migrationBuilder.DropIndex(
                name: "IX_SubPositionT_DepartmentId",
                table: "SubPositionT");

            migrationBuilder.DropIndex(
                name: "IX_SubPositionT_DivisionId",
                table: "SubPositionT");
        }
    }
}
