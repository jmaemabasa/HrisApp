using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrisApp.Server.Migrations
{
    public partial class i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogT");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "TrainingT",
                newName: "SponsorSpeaker");

            migrationBuilder.RenameColumn(
                name: "ProfMembership",
                table: "LicenseT",
                newName: "Rating");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SponsorSpeaker",
                table: "TrainingT",
                newName: "Remarks");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "LicenseT",
                newName: "ProfMembership");

            migrationBuilder.CreateTable(
                name: "AuditLogT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordID = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditLogT_UserMasterT_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMasterT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogT_UserId",
                table: "AuditLogT",
                column: "UserId");
        }
    }
}
