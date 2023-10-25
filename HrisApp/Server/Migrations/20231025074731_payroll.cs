using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class payroll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashBondT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBondT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryTypeT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryTypeT", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CashBondT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Yes" },
                    { 2, "No" }
                });

            migrationBuilder.InsertData(
                table: "SalaryTypeT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Monthly Rate" },
                    { 2, "Daily Rate" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashBondT");

            migrationBuilder.DropTable(
                name: "SalaryTypeT");
        }
    }
}
