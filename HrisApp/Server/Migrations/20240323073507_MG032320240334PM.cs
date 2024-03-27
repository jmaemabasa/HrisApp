using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG032320240334PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "AssetVehicleImageT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_AssetVehicleImageT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetVehicleImageT_AssetCategoryT_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetVehicleImageT_AssetSubCategoryT_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "AssetSubCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsumablesT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JMCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Cons_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cons_Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchaseAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumablesT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumablesT_AreaT_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AreaT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumablesT_AssetCategoryT_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumablesT_AssetSubCategoryT_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "AssetSubCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumablesT_AssetTypesT_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AssetTypesT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsumablesT_EmployeeT_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "EmployeeT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UOMT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UOMT", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetVehicleImageT_CategoryId",
                table: "AssetVehicleImageT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetVehicleImageT_SubCategoryId",
                table: "AssetVehicleImageT",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesT_AreaId",
                table: "ConsumablesT",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesT_CategoryId",
                table: "ConsumablesT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesT_CreatedById",
                table: "ConsumablesT",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesT_SubCategoryId",
                table: "ConsumablesT",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesT_TypeId",
                table: "ConsumablesT",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetVehicleImageT");

            migrationBuilder.DropTable(
                name: "ConsumablesT");

            migrationBuilder.DropTable(
                name: "UOMT");
        }
    }
}
