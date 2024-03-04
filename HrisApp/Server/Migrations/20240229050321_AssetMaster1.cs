using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class AssetMaster1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetMasterHistoryT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainAssetId = table.Column<int>(type: "int", nullable: false),
                    MainAssetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedDateReleased = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedDateToReturn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMasterHistoryT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetMasterHistoryT_AssetMasterT_MainAssetId",
                        column: x => x.MainAssetId,
                        principalTable: "AssetMasterT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterHistoryT_MainAssetId",
                table: "AssetMasterHistoryT",
                column: "MainAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetMasterHistoryT");
        }
    }
}
