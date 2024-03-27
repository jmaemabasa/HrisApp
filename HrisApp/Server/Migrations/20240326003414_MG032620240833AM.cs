using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG032620240833AM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cons_TransactionT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transact_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transact_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsumableId = table.Column<int>(type: "int", nullable: false),
                    ConsumableCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    Transact_Qty = table.Column<int>(type: "int", nullable: false),
                    Total_Qty = table.Column<int>(type: "int", nullable: false),
                    PurchasedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchaseAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PricePerUOM = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cons_TransactionT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cons_TransactionT_ConsumablesT_ConsumableId",
                        column: x => x.ConsumableId,
                        principalTable: "ConsumablesT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cons_TransactionT_DepartmentT_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cons_TransactionT_EmployeeT_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "EmployeeT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cons_TransactionT_EmployeeT_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cons_TransactionT_ConsumableId",
                table: "Cons_TransactionT",
                column: "ConsumableId");

            migrationBuilder.CreateIndex(
                name: "IX_Cons_TransactionT_CreatedById",
                table: "Cons_TransactionT",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cons_TransactionT_DepartmentId",
                table: "Cons_TransactionT",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cons_TransactionT_EmployeeId",
                table: "Cons_TransactionT",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cons_TransactionT");
        }
    }
}
