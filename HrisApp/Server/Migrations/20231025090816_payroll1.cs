using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class payroll1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "RateTypeT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateTypeT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleTypeT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeOut = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTypeT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayrollT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RateTypeId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashbondId = table.Column<int>(type: "int", nullable: false),
                    MealAllowance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BiometricID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAcc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TINNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSSNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhilHealthNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HDMFNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Restday = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleTypeId = table.Column<int>(type: "int", nullable: false),
                    Paytype = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollT_CashBondT_CashbondId",
                        column: x => x.CashbondId,
                        principalTable: "CashBondT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollT_RateTypeT_RateTypeId",
                        column: x => x.RateTypeId,
                        principalTable: "RateTypeT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollT_ScheduleTypeT_ScheduleTypeId",
                        column: x => x.ScheduleTypeId,
                        principalTable: "ScheduleTypeT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RateTypeT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Monthly Rate" },
                    { 2, "Daily Rate" }
                });

            migrationBuilder.InsertData(
                table: "ScheduleTypeT",
                columns: new[] { "Id", "Name", "TimeIn", "TimeOut" },
                values: new object[,]
                {
                    { 1, "Regular", "8:00 AM", "5:00 PM" },
                    { 2, "On Call", "8:00 AM", "5:00 PM" },
                    { 3, "Night Shift", "8:00 PM", "5:00 AM" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayrollT_CashbondId",
                table: "PayrollT",
                column: "CashbondId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollT_RateTypeId",
                table: "PayrollT",
                column: "RateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollT_ScheduleTypeId",
                table: "PayrollT",
                column: "ScheduleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayrollT");

            migrationBuilder.DropTable(
                name: "RateTypeT");

            migrationBuilder.DropTable(
                name: "ScheduleTypeT");

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
                table: "SalaryTypeT",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Monthly Rate" });

            migrationBuilder.InsertData(
                table: "SalaryTypeT",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Daily Rate" });
        }
    }
}
