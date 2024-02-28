using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MainAssAcc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "AssetMasterT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "AssetAccessoryT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MainAssetAccessoriesT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetMasterId = table.Column<int>(type: "int", nullable: false),
                    AssetMasterCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetAccessoryId = table.Column<int>(type: "int", nullable: false),
                    AssetAccessoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUsed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateStatusChanged = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainAssetAccessoriesT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainAssetAccessoriesT_AssetAccessoryT_AssetAccessoryId",
                        column: x => x.AssetAccessoryId,
                        principalTable: "AssetAccessoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainAssetAccessoriesT_AssetMasterT_AssetMasterId",
                        column: x => x.AssetMasterId,
                        principalTable: "AssetMasterT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetAccessoriesT_AssetAccessoryId",
                table: "MainAssetAccessoriesT",
                column: "AssetAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetAccessoriesT_AssetMasterId",
                table: "MainAssetAccessoriesT",
                column: "AssetMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainAssetAccessoriesT");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "AssetMasterT");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "AssetAccessoryT");
        }
    }
}
