using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class timetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "AttendanceRecordT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ShiftTimetableT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timetable_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnDuty_Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    OffDuty_Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    Begin_C_In = table.Column<TimeSpan>(type: "time", nullable: true),
                    Ending_C_In = table.Column<TimeSpan>(type: "time", nullable: true),
                    Begin_C_Out = table.Column<TimeSpan>(type: "time", nullable: true),
                    Ending_C_Out = table.Column<TimeSpan>(type: "time", nullable: true),
                    Workday_Count = table.Column<int>(type: "int", nullable: false),
                    Minute_Count = table.Column<int>(type: "int", nullable: false),
                    Late_Time = table.Column<int>(type: "int", nullable: false),
                    LeaveEarly_Time = table.Column<int>(type: "int", nullable: false),
                    Must_C_In = table.Column<bool>(type: "bit", nullable: false),
                    Must_C_Out = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTimetableT", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShiftTimetableT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "AttendanceRecordT",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
