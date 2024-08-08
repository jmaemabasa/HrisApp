using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG071520240323 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BioModelArchiveT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineNumber = table.Column<int>(type: "int", nullable: false),
                    IndRegID = table.Column<int>(type: "int", nullable: false),
                    DateTimeRecord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOnlyRecord = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOnlyRecord = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttendanceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioModelArchiveT", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BioModelArchiveT");
        }
    }
}
