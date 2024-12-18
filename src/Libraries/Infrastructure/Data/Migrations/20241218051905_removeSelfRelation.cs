using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractorDocuments.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeSelfRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Materials_ParentMaterialId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Measures_MeasureId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_MeasureId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_ParentMaterialId",
                table: "Materials");

            migrationBuilder.AddColumn<Guid>(
                name: "MeasureEntityId",
                table: "Materials",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MeasureEntityId",
                table: "Materials",
                column: "MeasureEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Measures_MeasureEntityId",
                table: "Materials",
                column: "MeasureEntityId",
                principalTable: "Measures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Measures_MeasureEntityId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_MeasureEntityId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MeasureEntityId",
                table: "Materials");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MeasureId",
                table: "Materials",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ParentMaterialId",
                table: "Materials",
                column: "ParentMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Materials_ParentMaterialId",
                table: "Materials",
                column: "ParentMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Measures_MeasureId",
                table: "Materials",
                column: "MeasureId",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
