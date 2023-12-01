using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class pos4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PositionComAppT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionComAppT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionKnowledgeT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KnowName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionKnowledgeT", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionComAppT");

            migrationBuilder.DropTable(
                name: "PositionKnowledgeT");
        }
    }
}
