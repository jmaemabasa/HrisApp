using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class eval9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emp_EvaluationT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_Emp_EvaluationT", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeEvaluationT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeVerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_EmployeeEvaluationT", x => x.Id);
                });
        }
    }
}
