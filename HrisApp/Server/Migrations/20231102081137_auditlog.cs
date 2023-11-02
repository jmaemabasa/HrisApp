using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class auditlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ScheduleTypeT",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ScheduleTypeT",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "AuditLogT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordID = table.Column<int>(type: "int", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditLogT_UserMasterT_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMasterT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "DivisionT",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Sales Operations");

            migrationBuilder.UpdateData(
                table: "DivisionT",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "FAMS");

            migrationBuilder.UpdateData(
                table: "DivisionT",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Central Administration");

            migrationBuilder.UpdateData(
                table: "DivisionT",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Agro Industrial");

            migrationBuilder.UpdateData(
                table: "ScheduleTypeT",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TimeIn", "TimeOut" },
                values: new object[] { "08:00 AM", "05:00 PM" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogT_UserId",
                table: "AuditLogT",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogT");

            migrationBuilder.UpdateData(
                table: "DivisionT",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Sales Operations Division");

            migrationBuilder.UpdateData(
                table: "DivisionT",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Finance Accounting Management Service Division");

            migrationBuilder.UpdateData(
                table: "DivisionT",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Central Administration Division");

            migrationBuilder.UpdateData(
                table: "DivisionT",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Agro Industrial Division");

            migrationBuilder.UpdateData(
                table: "ScheduleTypeT",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TimeIn", "TimeOut" },
                values: new object[] { "8:00 AM", "5:00 PM" });

            migrationBuilder.InsertData(
                table: "ScheduleTypeT",
                columns: new[] { "Id", "Name", "TimeIn", "TimeOut" },
                values: new object[,]
                {
                    { 2, "On Call", "8:00 AM", "5:00 PM" },
                    { 3, "Night Shift", "8:00 PM", "5:00 AM" }
                });
        }
    }
}
