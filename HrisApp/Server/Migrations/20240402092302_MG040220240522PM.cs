using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG040220240522PM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetLicenseRemarksT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseAssetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerifyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLicenseRemarksT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetLicenseT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JMCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    AssetStatusId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchaseAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InUseStatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EUF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastCheckDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MainAssetId = table.Column<int>(type: "int", nullable: true),
                    MainAssetDateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLicenseT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetLicenseT_AssetCategoryT_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetLicenseT_AssetMasterT_MainAssetId",
                        column: x => x.MainAssetId,
                        principalTable: "AssetMasterT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssetLicenseT_AssetStatusT_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetLicenseT_AssetSubCategoryT_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "AssetSubCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetLicenseT_AssetTypesT_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AssetTypesT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssetLicenseT_EmployeeT_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "EmployeeT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssLicenseImageT",
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
                    table.PrimaryKey("PK_AssLicenseImageT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssLicenseImageT_AssetCategoryT_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AssetCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssLicenseImageT_AssetSubCategoryT_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "AssetSubCategoryT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AssetLicenseHistoryT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetLicenseId = table.Column<int>(type: "int", nullable: false),
                    MainAssetId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    AssignedDateMainAss = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnassignedDateMainAss = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLicenseHistoryT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetLicenseHistoryT_AssetLicenseT_AssetLicenseId",
                        column: x => x.AssetLicenseId,
                        principalTable: "AssetLicenseT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetLicenseHistoryT_AssetMasterT_MainAssetId",
                        column: x => x.MainAssetId,
                        principalTable: "AssetMasterT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetLicenseHistoryT_EmployeeT_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetLicenseHistoryT_AssetLicenseId",
                table: "AssetLicenseHistoryT",
                column: "AssetLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLicenseHistoryT_EmployeeId",
                table: "AssetLicenseHistoryT",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLicenseHistoryT_MainAssetId",
                table: "AssetLicenseHistoryT",
                column: "MainAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLicenseT_AssetStatusId",
                table: "AssetLicenseT",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLicenseT_CategoryId",
                table: "AssetLicenseT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLicenseT_CreatedById",
                table: "AssetLicenseT",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLicenseT_MainAssetId",
                table: "AssetLicenseT",
                column: "MainAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLicenseT_SubCategoryId",
                table: "AssetLicenseT",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLicenseT_TypeId",
                table: "AssetLicenseT",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssLicenseImageT_CategoryId",
                table: "AssLicenseImageT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssLicenseImageT_SubCategoryId",
                table: "AssLicenseImageT",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetLicenseHistoryT");

            migrationBuilder.DropTable(
                name: "AssetLicenseRemarksT");

            migrationBuilder.DropTable(
                name: "AssLicenseImageT");

            migrationBuilder.DropTable(
                name: "AssetLicenseT");
        }
    }
}
