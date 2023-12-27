using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class laeve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveTypesT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypesT", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LeaveTypesT",
                columns: new[] { "Id", "Description", "Name", "Unit" },
                values: new object[,]
                {
                    { 1, "Day", "Emergency", 1.0 },
                    { 2, "Day", "Maternity", 1.0 },
                    { 3, "Day", "Paternity", 1.0 },
                    { 4, "Day", "Sick", 1.0 },
                    { 5, "Day", "Vacation", 1.0 },
                    { 6, "Day", "Other", 1.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveTypesT");
        }
    }
}
