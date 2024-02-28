using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class assetmaster1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssetMasterTId",
                table: "AssetAccessoryT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssetMasterT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorksationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MacAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchaseAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetStatusId = table.Column<int>(type: "int", nullable: false),
                    InUseStatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssetNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsernameAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastCheckDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AssetAccessoryId = table.Column<int>(type: "int", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMasterT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetMasterT_AssetAccessoryT_AssetAccessoryId",
                        column: x => x.AssetAccessoryId,
                        principalTable: "AssetAccessoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetMasterT_AssetCategoryT_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetMasterT_AssetStatusT_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetMasterT_AssetSubCategoryT_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "AssetSubCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetMasterT_AssetTypesT_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AssetTypesT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetMasterT_EmployeeT_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetAccessoryT_AssetMasterTId",
                table: "AssetAccessoryT",
                column: "AssetMasterTId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_AssetAccessoryId",
                table: "AssetMasterT",
                column: "AssetAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_AssetStatusId",
                table: "AssetMasterT",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_CategoryId",
                table: "AssetMasterT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_EmployeeId",
                table: "AssetMasterT",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_SubCategoryId",
                table: "AssetMasterT",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasterT_TypeId",
                table: "AssetMasterT",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAccessoryT_AssetMasterT_AssetMasterTId",
                table: "AssetAccessoryT",
                column: "AssetMasterTId",
                principalTable: "AssetMasterT",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAccessoryT_AssetMasterT_AssetMasterTId",
                table: "AssetAccessoryT");

            migrationBuilder.DropTable(
                name: "AssetMasterT");

            migrationBuilder.DropIndex(
                name: "IX_AssetAccessoryT_AssetMasterTId",
                table: "AssetAccessoryT");

            migrationBuilder.DropColumn(
                name: "AssetMasterTId",
                table: "AssetAccessoryT");
        }
    }
}
