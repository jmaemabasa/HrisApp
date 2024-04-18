using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG041820240408PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BioIPModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Device_Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Machine = table.Column<int>(type: "int", nullable: false),
                    Machine_Reg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Is_AM = table.Column<bool>(type: "bit", nullable: false),
                    Is_PM = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioIPModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtractLogsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeUserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Start = table.Column<bool>(type: "bit", nullable: false),
                    Date_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_Stop = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtractLogsModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BioIPModel");

            migrationBuilder.DropTable(
                name: "ExtractLogsModel");
        }
    }
}
