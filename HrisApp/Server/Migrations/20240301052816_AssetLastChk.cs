using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class AssetLastChk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetLastCheckT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainAssetId = table.Column<int>(type: "int", nullable: true),
                    LastCheckDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLastCheckT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetLastCheckT_AssetMasterT_MainAssetId",
                        column: x => x.MainAssetId,
                        principalTable: "AssetMasterT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetLastCheckT_MainAssetId",
                table: "AssetLastCheckT",
                column: "MainAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetLastCheckT");
        }
    }
}
