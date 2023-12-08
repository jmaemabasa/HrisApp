using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class manpower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PosMPExternalT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    External_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    External_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosMPExternalT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PosMPInternalT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Internal_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Internal_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosMPInternalT", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PosMPExternalT");

            migrationBuilder.DropTable(
                name: "PosMPInternalT");
        }
    }
}
