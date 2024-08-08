using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG073120240208 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainAssetImgLogT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgVerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_Filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_Contenttype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    Img_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Img_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JM_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainAssetImgLogT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainAssetImgLogT_AssetCategoryT_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MainAssetImgLogT_AssetSubCategoryT_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "AssetSubCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetImgLogT_CategoryId",
                table: "MainAssetImgLogT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetImgLogT_SubCategoryId",
                table: "MainAssetImgLogT",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainAssetImgLogT");
        }
    }
}
