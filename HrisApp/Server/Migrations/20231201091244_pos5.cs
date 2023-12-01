using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class pos5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerApp",
                table: "PositionT");

            migrationBuilder.DropColumn(
                name: "KnowledgeOf",
                table: "PositionT");

            migrationBuilder.DropColumn(
                name: "TechnicalSkills",
                table: "PositionT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComputerApp",
                table: "PositionT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KnowledgeOf",
                table: "PositionT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TechnicalSkills",
                table: "PositionT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ComputerApp", "KnowledgeOf", "TechnicalSkills" },
                values: new object[] { "", "", "" });
        }
    }
}
