using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MainAssAcc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetAccessoryCode",
                table: "MainAssetAccessoriesT");

            migrationBuilder.DropColumn(
                name: "MainAsset",
                table: "AssetAccessoryT");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MainAssetAccessoriesT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "MainAssetAccessoriesT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "MainAssetDateUpdated",
                table: "AssetAccessoryT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainAssetId",
                table: "AssetAccessoryT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetAccessoriesT_CategoryId",
                table: "MainAssetAccessoriesT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MainAssetAccessoriesT_SubCategoryId",
                table: "MainAssetAccessoriesT",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoryT_MainAssetId",
                table: "AssetAccessoryT",
                column: "MainAssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAccessoryT_AssetMasterT_MainAssetId",
                table: "AssetAccessoryT",
                column: "MainAssetId",
                principalTable: "AssetMasterT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainAssetAccessoriesT_AssetCategoryT_CategoryId",
                table: "MainAssetAccessoriesT",
                column: "CategoryId",
                principalTable: "AssetCategoryT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MainAssetAccessoriesT_AssetSubCategoryT_SubCategoryId",
                table: "MainAssetAccessoriesT",
                column: "SubCategoryId",
                principalTable: "AssetSubCategoryT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAccessoryT_AssetMasterT_MainAssetId",
                table: "AssetAccessoryT");

            migrationBuilder.DropForeignKey(
                name: "FK_MainAssetAccessoriesT_AssetCategoryT_CategoryId",
                table: "MainAssetAccessoriesT");

            migrationBuilder.DropForeignKey(
                name: "FK_MainAssetAccessoriesT_AssetSubCategoryT_SubCategoryId",
                table: "MainAssetAccessoriesT");

            migrationBuilder.DropIndex(
                name: "IX_MainAssetAccessoriesT_CategoryId",
                table: "MainAssetAccessoriesT");

            migrationBuilder.DropIndex(
                name: "IX_MainAssetAccessoriesT_SubCategoryId",
                table: "MainAssetAccessoriesT");

            migrationBuilder.DropIndex(
                name: "IX_AssetAccessoryT_MainAssetId",
                table: "AssetAccessoryT");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MainAssetAccessoriesT");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "MainAssetAccessoriesT");

            migrationBuilder.DropColumn(
                name: "MainAssetDateUpdated",
                table: "AssetAccessoryT");

            migrationBuilder.DropColumn(
                name: "MainAssetId",
                table: "AssetAccessoryT");

            migrationBuilder.AddColumn<string>(
                name: "AssetAccessoryCode",
                table: "MainAssetAccessoriesT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainAsset",
                table: "AssetAccessoryT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
