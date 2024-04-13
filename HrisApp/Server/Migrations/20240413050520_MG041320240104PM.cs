using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG041320240104PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emp_UndergraduateT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UGSchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UGSchoolLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UGAward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UGSchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UGCourse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_UndergraduateT", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emp_UndergraduateT");
        }
    }
}
