using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class eval2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateEvaluate",
                table: "Emp_EvaluationT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateHired",
                table: "Emp_EvaluationT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimesEvaluate",
                table: "Emp_EvaluationT",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEvaluate",
                table: "Emp_EvaluationT");

            migrationBuilder.DropColumn(
                name: "DateHired",
                table: "Emp_EvaluationT");

            migrationBuilder.DropColumn(
                name: "TimesEvaluate",
                table: "Emp_EvaluationT");
        }
    }
}
