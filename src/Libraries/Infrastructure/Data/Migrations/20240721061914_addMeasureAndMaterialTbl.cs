using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractorDocuments.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addMeasureAndMaterialTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SystemKeyword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Materials_ParentMaterialId",
                        column: x => x.ParentMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Materials_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MeasureId",
                table: "Materials",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ParentMaterialId",
                table: "Materials",
                column: "ParentMaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Measures");
        }
    }
}
