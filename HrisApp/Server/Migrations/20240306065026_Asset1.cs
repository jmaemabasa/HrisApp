using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class Asset1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedDateMainAss",
                table: "AssetAccessoryT");

            migrationBuilder.DropColumn(
                name: "UnassignedDateMainAss",
                table: "AssetAccessoryT");

            migrationBuilder.CreateTable(
                name: "AssetAccessHistoryT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetAccessoryId = table.Column<int>(type: "int", nullable: false),
                    MainAssetId = table.Column<int>(type: "int", nullable: false),
                    AssignedDateMainAss = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnassignedDateMainAss = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAccessHistoryT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetAccessHistoryT_AssetAccessoryT_AssetAccessoryId",
                        column: x => x.AssetAccessoryId,
                        principalTable: "AssetAccessoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetAccessHistoryT_AssetMasterT_MainAssetId",
                        column: x => x.MainAssetId,
                        principalTable: "AssetMasterT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessHistoryT_AssetAccessoryId",
                table: "AssetAccessHistoryT",
                column: "AssetAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessHistoryT_MainAssetId",
                table: "AssetAccessHistoryT",
                column: "MainAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetAccessHistoryT");

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedDateMainAss",
                table: "AssetAccessoryT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnassignedDateMainAss",
                table: "AssetAccessoryT",
                type: "datetime2",
                nullable: true);
        }
    }
}
