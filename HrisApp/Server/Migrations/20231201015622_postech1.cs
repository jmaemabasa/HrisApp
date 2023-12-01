using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class postech1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionTechSkillT_PositionT_PositionId",
                table: "PositionTechSkillT");

            migrationBuilder.DropIndex(
                name: "IX_PositionTechSkillT_PositionId",
                table: "PositionTechSkillT");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "PositionTechSkillT");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PositionTechSkillT",
                newName: "SkillName");

            migrationBuilder.AddColumn<string>(
                name: "PosCode",
                table: "PositionTechSkillT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosCode",
                table: "PositionTechSkillT");

            migrationBuilder.RenameColumn(
                name: "SkillName",
                table: "PositionTechSkillT",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "PositionTechSkillT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PositionTechSkillT_PositionId",
                table: "PositionTechSkillT",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionTechSkillT_PositionT_PositionId",
                table: "PositionTechSkillT",
                column: "PositionId",
                principalTable: "PositionT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
