using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG040120240836AM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "Eval4Status",
               table: "Emp_EvaluationT");

            migrationBuilder.DropColumn(
                name: "Eval6Status",
                table: "Emp_EvaluationT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
