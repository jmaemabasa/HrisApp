using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG032720241141AM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseAmount",
                table: "ConsumablesT");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerUOM",
                table: "ConsumablesT",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPurchaseAmount",
                table: "ConsumablesT",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerUOM",
                table: "ConsumablesT");

            migrationBuilder.DropColumn(
                name: "TotalPurchaseAmount",
                table: "ConsumablesT");

            migrationBuilder.AddColumn<string>(
                name: "PurchaseAmount",
                table: "ConsumablesT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
