using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CivilStatusT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilStatusT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DivisionT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmerRelationshipT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmerRelationshipT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentStatusT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentStatusT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenderT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InactiveStatusT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InactiveStatusT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReligionT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReligionT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMasterT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LoginStatus = table.Column<bool>(type: "bit", nullable: false),
                    ReferralCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMasterT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verify_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    CivilStatusId = table.Column<int>(type: "int", nullable: false),
                    ReligionId = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmerRelationshipId = table.Column<int>(type: "int", nullable: false),
                    EmerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmerMobNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateHired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmploymentStatusId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    InactiveStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeT_AreaT_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AreaT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_CivilStatusT_CivilStatusId",
                        column: x => x.CivilStatusId,
                        principalTable: "CivilStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_DepartmentT_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_DivisionT_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "DivisionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_EmerRelationshipT_EmerRelationshipId",
                        column: x => x.EmerRelationshipId,
                        principalTable: "EmerRelationshipT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_EmploymentStatusT_EmploymentStatusId",
                        column: x => x.EmploymentStatusId,
                        principalTable: "EmploymentStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_GenderT_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GenderT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_InactiveStatusT_InactiveStatusId",
                        column: x => x.InactiveStatusId,
                        principalTable: "InactiveStatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_PositionT_PositionId",
                        column: x => x.PositionId,
                        principalTable: "PositionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_ReligionT_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "ReligionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_SectionT_SectionId",
                        column: x => x.SectionId,
                        principalTable: "SectionT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeT_StatusT_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AreaT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Davao" },
                    { 2, "Digos" },
                    { 3, "Kidapawan" },
                    { 4, "Cotabato" },
                    { 5, "Calinan" },
                    { 6, "Gumalang" }
                });

            migrationBuilder.InsertData(
                table: "CivilStatusT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Single" },
                    { 2, "Married" },
                    { 3, "Widowed" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentT",
                columns: new[] { "Id", "DivisionId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Sonic 1" },
                    { 2, 1, "Sonic 2" },
                    { 3, 1, "Sonic 3 Digos" },
                    { 4, 1, "Sonic 3 Kidapawan" },
                    { 5, 1, "Sonic 3 Cotabato" },
                    { 6, 1, "URIC" },
                    { 7, 1, "UFS" },
                    { 8, 1, "GCash" },
                    { 9, 2, "Sales Accounting" },
                    { 10, 2, "Credit and Collection" },
                    { 11, 2, "Accounts Receivable" },
                    { 12, 2, "General Accounting" },
                    { 13, 2, "Accounts Payable" },
                    { 14, 2, "General Accounting" },
                    { 15, 2, "Tax Compliance" },
                    { 16, 2, "Information Technology" },
                    { 17, 2, "Cash Operations" },
                    { 18, 3, "Warehouse" },
                    { 19, 3, "Transport" },
                    { 20, 3, "Inventory Planning and Principal Relations" },
                    { 21, 3, "Order Processing" },
                    { 22, 3, "Logistics" },
                    { 23, 4, "Human Resource" },
                    { 24, 4, "General Services" },
                    { 25, 5, "Canaan" },
                    { 26, 5, "RTL" },
                    { 27, 5, "Pullet" }
                });

            migrationBuilder.InsertData(
                table: "DivisionT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sales Operations Division" },
                    { 2, "Finance Accounting Management Service Division" },
                    { 3, "Supply Chain Management Service" },
                    { 4, "Central Administration Division" },
                    { 5, "Agro Industrial Division" }
                });

            migrationBuilder.InsertData(
                table: "EmerRelationshipT",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Mother" });

            migrationBuilder.InsertData(
                table: "EmerRelationshipT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Father" },
                    { 3, "Spouse" },
                    { 4, "Sibling" }
                });

            migrationBuilder.InsertData(
                table: "EmploymentStatusT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Regular" },
                    { 2, "Probationary" },
                    { 3, "Casual" },
                    { 4, "Fixed Term" },
                    { 5, "Project Based" }
                });

            migrationBuilder.InsertData(
                table: "GenderT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "InactiveStatusT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Resigned" },
                    { 2, "Terminated" },
                    { 3, "Awol" },
                    { 4, "Retired" }
                });

            migrationBuilder.InsertData(
                table: "ReligionT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Roman Catholic" },
                    { 2, "Iglesia ni Cristo" },
                    { 3, "Evangelicals (PCEC)" },
                    { 4, "Non-Roman Catholic" },
                    { 5, "Protestant (NCCP)" },
                    { 6, "Aglipayan" },
                    { 7, "Seventh-day Adventist" },
                    { 8, "Bible Baptist Church" },
                    { 9, "United Church of Christ in the Philippines" },
                    { 10, "Jehovah's Witnesses" },
                    { 11, "None" },
                    { 12, "Others" }
                });

            migrationBuilder.InsertData(
                table: "StatusT",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_AreaId",
                table: "EmployeeT",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_CivilStatusId",
                table: "EmployeeT",
                column: "CivilStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_DepartmentId",
                table: "EmployeeT",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_DivisionId",
                table: "EmployeeT",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_EmerRelationshipId",
                table: "EmployeeT",
                column: "EmerRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_EmploymentStatusId",
                table: "EmployeeT",
                column: "EmploymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_GenderId",
                table: "EmployeeT",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_InactiveStatusId",
                table: "EmployeeT",
                column: "InactiveStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_PositionId",
                table: "EmployeeT",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_ReligionId",
                table: "EmployeeT",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_SectionId",
                table: "EmployeeT",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_StatusId",
                table: "EmployeeT",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeT");

            migrationBuilder.DropTable(
                name: "UserMasterT");

            migrationBuilder.DropTable(
                name: "AreaT");

            migrationBuilder.DropTable(
                name: "CivilStatusT");

            migrationBuilder.DropTable(
                name: "DepartmentT");

            migrationBuilder.DropTable(
                name: "DivisionT");

            migrationBuilder.DropTable(
                name: "EmerRelationshipT");

            migrationBuilder.DropTable(
                name: "EmploymentStatusT");

            migrationBuilder.DropTable(
                name: "GenderT");

            migrationBuilder.DropTable(
                name: "InactiveStatusT");

            migrationBuilder.DropTable(
                name: "PositionT");

            migrationBuilder.DropTable(
                name: "ReligionT");

            migrationBuilder.DropTable(
                name: "SectionT");

            migrationBuilder.DropTable(
                name: "StatusT");
        }
    }
}
