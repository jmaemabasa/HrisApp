using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 16,
                column: "PosCode",
                value: "URICHAP01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 17,
                column: "PosCode",
                value: "URICHAP02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Name", "PosCode" },
                values: new object[] { "Field Sales Supervisor", "URICSER01" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 19,
                column: "PosCode",
                value: "URICSER02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 20,
                column: "PosCode",
                value: "URICSER03");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 21,
                column: "PosCode",
                value: "URICSER04");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 22,
                column: "PosCode",
                value: "URICEXP01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 23,
                column: "PosCode",
                value: "URICEXP02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 24,
                column: "PosCode",
                value: "URICEXP02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 25,
                column: "PosCode",
                value: "URICDTE01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 26,
                column: "PosCode",
                value: "URICDTE02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 29,
                column: "PosCode",
                value: "GCASHSER01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 30,
                column: "PosCode",
                value: "GCASHSER02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 31,
                column: "PosCode",
                value: "GCASHSER03");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 32,
                column: "PosCode",
                value: "GCASHEXP01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 33,
                column: "PosCode",
                value: "GCASHMER01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 34,
                column: "PosCode",
                value: "GCASHSCA01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 35,
                column: "PosCode",
                value: "GAINV01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 36,
                column: "PosCode",
                value: "GAINV02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 37,
                column: "PosCode",
                value: "GAINV03");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 38,
                column: "PosCode",
                value: "GAGEN01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 39,
                column: "PosCode",
                value: "GAGEN02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 40,
                column: "PosCode",
                value: "GATAX01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 41,
                column: "PosCode",
                value: "GATAX02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 42,
                column: "PosCode",
                value: "SAACC01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 43,
                column: "PosCode",
                value: "SAACC02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 44,
                column: "PosCode",
                value: "SACRE01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 45,
                column: "PosCode",
                value: "SACRE02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "PosCode", "SectionId" },
                values: new object[] { "SABIL01", 17 });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 50,
                column: "PosCode",
                value: "TREASURYCAS01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 51,
                column: "PosCode",
                value: "TREASURYCAS02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 52,
                column: "PosCode",
                value: "TREASURYCAS03");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 53,
                column: "PosCode",
                value: "TREASURYCAS04");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 54,
                column: "PosCode",
                value: "TREASURYCAS05");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 16,
                column: "PosCode",
                value: "URIC02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 17,
                column: "PosCode",
                value: "URIC03");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Name", "PosCode" },
                values: new object[] { "FIELD SALES Supervisor", "URIC04" });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 19,
                column: "PosCode",
                value: "URIC05");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 20,
                column: "PosCode",
                value: "URIC06");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 21,
                column: "PosCode",
                value: "URIC07");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 22,
                column: "PosCode",
                value: "URIC08");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 23,
                column: "PosCode",
                value: "URIC09");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 24,
                column: "PosCode",
                value: "URIC10");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 25,
                column: "PosCode",
                value: "URIC11");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 26,
                column: "PosCode",
                value: "URIC12");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 29,
                column: "PosCode",
                value: "GCASH03");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 30,
                column: "PosCode",
                value: "GCASH04");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 31,
                column: "PosCode",
                value: "GCASH05");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 32,
                column: "PosCode",
                value: "GCASH06");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 33,
                column: "PosCode",
                value: "GCASH07");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 34,
                column: "PosCode",
                value: "GCASH08");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 35,
                column: "PosCode",
                value: "GAIAP01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 36,
                column: "PosCode",
                value: "GAIAP02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 37,
                column: "PosCode",
                value: "GAIAP03");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 38,
                column: "PosCode",
                value: "GAGA04");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 39,
                column: "PosCode",
                value: "GAGA05");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 40,
                column: "PosCode",
                value: "GATC06");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 41,
                column: "PosCode",
                value: "GATC07");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 42,
                column: "PosCode",
                value: "SAAR08");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 43,
                column: "PosCode",
                value: "SAAR09");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 44,
                column: "PosCode",
                value: "SACC10");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 45,
                column: "PosCode",
                value: "SACC11");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "PosCode", "SectionId" },
                values: new object[] { "SABCS012", 16 });

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 50,
                column: "PosCode",
                value: "TCO01");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 51,
                column: "PosCode",
                value: "TCO02");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 52,
                column: "PosCode",
                value: "TCO03");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 53,
                column: "PosCode",
                value: "TCO04");

            migrationBuilder.UpdateData(
                table: "PositionT",
                keyColumn: "Id",
                keyValue: 54,
                column: "PosCode",
                value: "TCO05");
        }
    }
}
