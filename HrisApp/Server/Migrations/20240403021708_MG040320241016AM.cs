using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG040320241016AM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainAssetLicensesT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetMasterId = table.Column<int>(type: "int", nullable: false),
                    AssetMasterCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetLicenseId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    DateUsed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateStatusChanged = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainAssetLicensesT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainAssetLicensesT_AssetCategoryT_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MainAssetLicensesT_AssetLicenseT_AssetLicenseId",
                        column: x => x.AssetLicenseId,
                        principalTable: "AssetLicenseT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MainAssetLicensesT_AssetMasterT_AssetMasterId",
                        column: x => x.AssetMasterId,
                        principalTable: "AssetMasterT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MainAssetLicensesT_AssetSubCategoryT_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "AssetSubCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetLicensesT_AssetLicenseId",
                table: "MainAssetLicensesT",
                column: "AssetLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetLicensesT_AssetMasterId",
                table: "MainAssetLicensesT",
                column: "AssetMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetLicensesT_CategoryId",
                table: "MainAssetLicensesT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetLicensesT_SubCategoryId",
                table: "MainAssetLicensesT",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainAssetLicensesT");
        }
    }
}
