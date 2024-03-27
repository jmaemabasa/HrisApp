using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class MG032120240526 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "AssetVehiclesT",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   JMCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   WorksationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   TypeId = table.Column<int>(type: "int", nullable: false),
                   CategoryId = table.Column<int>(type: "int", nullable: false),
                   SubCategoryId = table.Column<int>(type: "int", nullable: false),
                   AreaId = table.Column<int>(type: "int", nullable: false),
                   Quantity = table.Column<int>(type: "int", nullable: false),
                   Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   DeviceID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   ProductID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                   PurchaseAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   EUF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   EmployeeId = table.Column<int>(type: "int", nullable: true),
                   AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                   AssignedDateReleased = table.Column<DateTime>(type: "datetime2", nullable: true),
                   AssignedDateToReturn = table.Column<DateTime>(type: "datetime2", nullable: true),
                   AssetStatusId = table.Column<int>(type: "int", nullable: false),
                   InUseStatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                   StatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                   AssetNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Asset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   UsernameAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   PasswordAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   LastCheckDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                   DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                   CreatedById = table.Column<int>(type: "int", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_AssetVehiclesT", x => x.Id);
                   table.ForeignKey(
                       name: "FK_AssetVehiclesT_AreaT_AreaId",
                       column: x => x.AreaId,
                       principalTable: "AreaT",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_AssetVehiclesT_AssetCategoryT_CategoryId",
                       column: x => x.CategoryId,
                       principalTable: "AssetCategoryT",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_AssetVehiclesT_AssetStatusT_AssetStatusId",
                       column: x => x.AssetStatusId,
                       principalTable: "AssetStatusT",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_AssetVehiclesT_AssetSubCategoryT_SubCategoryId",
                       column: x => x.SubCategoryId,
                       principalTable: "AssetSubCategoryT",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_AssetVehiclesT_AssetTypesT_TypeId",
                       column: x => x.TypeId,
                       principalTable: "AssetTypesT",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_AssetVehiclesT_EmployeeT_CreatedById",
                       column: x => x.CreatedById,
                       principalTable: "EmployeeT",
                       principalColumn: "Id");
                   table.ForeignKey(
                       name: "FK_AssetVehiclesT_EmployeeT_EmployeeId",
                       column: x => x.EmployeeId,
                       principalTable: "EmployeeT",
                       principalColumn: "Id");
               });

            migrationBuilder.CreateIndex(
                name: "IX_AssetVehicleImageT_SubCategoryId",
                table: "AssetVehicleImageT",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetVehiclesT_AreaId",
                table: "AssetVehiclesT",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetVehiclesT_AssetStatusId",
                table: "AssetVehiclesT",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetVehiclesT_CategoryId",
                table: "AssetVehiclesT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetVehiclesT_CreatedById",
                table: "AssetVehiclesT",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AssetVehiclesT_EmployeeId",
                table: "AssetVehiclesT",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetVehiclesT_SubCategoryId",
                table: "AssetVehiclesT",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetVehiclesT_TypeId",
                table: "AssetVehiclesT",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "AssetVehiclesT");
        }
    }
}
