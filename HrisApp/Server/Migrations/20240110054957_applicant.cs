using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class applicant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_SelfDeclarationT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App_VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q1Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q1Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q2Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q2Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q3Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q3Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q4Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q4Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q5Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q5Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q6Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q6Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q7Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q7Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q8Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Q8Dtls = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_SelfDeclarationT", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_SelfDeclarationT");
        }
    }
}
