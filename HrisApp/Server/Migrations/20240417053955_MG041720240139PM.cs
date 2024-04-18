using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG041720240139PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BioModelT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineNumber = table.Column<int>(type: "int", nullable: false),
                    IndRegID = table.Column<int>(type: "int", nullable: false),
                    DateTimeRecord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOnlyRecord = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOnlyRecord = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioModelT", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BioModelT");
        }
    }
}
