using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class eval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeEvaluationT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eval1Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eval2Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eval3Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eval4Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eval5Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eval6Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEvaluationT", x => x.Verify_Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEvaluationT_EmployeeT_EmployeeId",
                        column: x => x.Verify_Id,
                        principalTable: "EmployeeT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluationT_EmployeeId",
                table: "EmployeeEvaluationT",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeEvaluationT");
        }
    }
}
