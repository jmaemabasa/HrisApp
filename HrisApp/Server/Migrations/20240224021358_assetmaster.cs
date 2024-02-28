using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class assetmaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetAccessoriesT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetAccessoriesT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Asset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetStatudId = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EUF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InUseStatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainAsset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAccessoriesT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetAccessoriesT_AssetCategoryT_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetAccessoriesT_AssetStatusT_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AssetStatusT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssetAccessoriesT_AssetSubCategoryT_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "AssetSubCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetAccessoriesT_AssetTypesT_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AssetTypesT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoriesT_CategoryId",
                table: "AssetAccessoriesT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoriesT_StatusId",
                table: "AssetAccessoriesT",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoriesT_SubCategoryId",
                table: "AssetAccessoriesT",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoriesT_TypeId",
                table: "AssetAccessoriesT",
                column: "TypeId");
        }
    }
}
