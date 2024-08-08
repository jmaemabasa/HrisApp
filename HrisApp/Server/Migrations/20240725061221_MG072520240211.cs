using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG072520240211 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategory2Id",
                table: "ConsumablesT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategory2Id",
                table: "AssetMasterT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategory2Id",
                table: "AssetLicenseT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategory2Id",
                table: "AssetAccessoryT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesT_SubCategory2Id",
                table: "ConsumablesT",
                column: "SubCategory2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_SubCategory2Id",
                table: "AssetMasterT",
                column: "SubCategory2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLicenseT_SubCategory2Id",
                table: "AssetLicenseT",
                column: "SubCategory2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoryT_SubCategory2Id",
                table: "AssetAccessoryT",
                column: "SubCategory2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAccessoryT_AssetSubCategory2T_SubCategory2Id",
                table: "AssetAccessoryT",
                column: "SubCategory2Id",
                principalTable: "AssetSubCategory2T",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLicenseT_AssetSubCategory2T_SubCategory2Id",
                table: "AssetLicenseT",
                column: "SubCategory2Id",
                principalTable: "AssetSubCategory2T",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMasterT_AssetSubCategory2T_SubCategory2Id",
                table: "AssetMasterT",
                column: "SubCategory2Id",
                principalTable: "AssetSubCategory2T",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumablesT_AssetSubCategory2T_SubCategory2Id",
                table: "ConsumablesT",
                column: "SubCategory2Id",
                principalTable: "AssetSubCategory2T",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAccessoryT_AssetSubCategory2T_SubCategory2Id",
                table: "AssetAccessoryT");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLicenseT_AssetSubCategory2T_SubCategory2Id",
                table: "AssetLicenseT");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMasterT_AssetSubCategory2T_SubCategory2Id",
                table: "AssetMasterT");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumablesT_AssetSubCategory2T_SubCategory2Id",
                table: "ConsumablesT");

            migrationBuilder.DropIndex(
                name: "IX_ConsumablesT_SubCategory2Id",
                table: "ConsumablesT");

            migrationBuilder.DropIndex(
                name: "IX_AssetMasterT_SubCategory2Id",
                table: "AssetMasterT");

            migrationBuilder.DropIndex(
                name: "IX_AssetLicenseT_SubCategory2Id",
                table: "AssetLicenseT");

            migrationBuilder.DropIndex(
                name: "IX_AssetAccessoryT_SubCategory2Id",
                table: "AssetAccessoryT");

            migrationBuilder.DropColumn(
                name: "SubCategory2Id",
                table: "ConsumablesT");

            migrationBuilder.DropColumn(
                name: "SubCategory2Id",
                table: "AssetMasterT");

            migrationBuilder.DropColumn(
                name: "SubCategory2Id",
                table: "AssetLicenseT");

            migrationBuilder.DropColumn(
                name: "SubCategory2Id",
                table: "AssetAccessoryT");
        }
    }
}
