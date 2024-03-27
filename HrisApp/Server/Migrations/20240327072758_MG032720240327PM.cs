using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG032720240327PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceNo",
                table: "Cons_TransactionT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "Cons_TransactionT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cons_TransactionT_VendorId",
                table: "Cons_TransactionT",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cons_TransactionT_VendorT_VendorId",
                table: "Cons_TransactionT",
                column: "VendorId",
                principalTable: "VendorT",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cons_TransactionT_VendorT_VendorId",
                table: "Cons_TransactionT");

            migrationBuilder.DropIndex(
                name: "IX_Cons_TransactionT_VendorId",
                table: "Cons_TransactionT");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                table: "Cons_TransactionT");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Cons_TransactionT");
        }
    }
}
