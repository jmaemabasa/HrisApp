using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG040520240953AM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAccessoryT_EmployeeT_CreatedById",
                table: "AssetAccessoryT");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLicenseT_EmployeeT_CreatedById",
                table: "AssetLicenseT");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMasterT_EmployeeT_CreatedById",
                table: "AssetMasterT");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumablesT_EmployeeT_CreatedById",
                table: "ConsumablesT");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "ConsumablesT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "AssetMasterT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "AssetLicenseT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "AssetAccessoryT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAccessoryT_EmployeeT_CreatedById",
                table: "AssetAccessoryT",
                column: "CreatedById",
                principalTable: "EmployeeT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLicenseT_EmployeeT_CreatedById",
                table: "AssetLicenseT",
                column: "CreatedById",
                principalTable: "EmployeeT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMasterT_EmployeeT_CreatedById",
                table: "AssetMasterT",
                column: "CreatedById",
                principalTable: "EmployeeT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumablesT_EmployeeT_CreatedById",
                table: "ConsumablesT",
                column: "CreatedById",
                principalTable: "EmployeeT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAccessoryT_EmployeeT_CreatedById",
                table: "AssetAccessoryT");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetLicenseT_EmployeeT_CreatedById",
                table: "AssetLicenseT");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetMasterT_EmployeeT_CreatedById",
                table: "AssetMasterT");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumablesT_EmployeeT_CreatedById",
                table: "ConsumablesT");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "ConsumablesT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");


            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "AssetMasterT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "AssetLicenseT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "AssetAccessoryT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAccessoryT_EmployeeT_CreatedById",
                table: "AssetAccessoryT",
                column: "CreatedById",
                principalTable: "EmployeeT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetLicenseT_EmployeeT_CreatedById",
                table: "AssetLicenseT",
                column: "CreatedById",
                principalTable: "EmployeeT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetMasterT_EmployeeT_CreatedById",
                table: "AssetMasterT",
                column: "CreatedById",
                principalTable: "EmployeeT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumablesT_EmployeeT_CreatedById",
                table: "ConsumablesT",
                column: "CreatedById",
                principalTable: "EmployeeT",
                principalColumn: "Id");
        }
    }
}
