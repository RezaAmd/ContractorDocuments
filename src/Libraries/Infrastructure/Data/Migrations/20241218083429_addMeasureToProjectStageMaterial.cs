using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractorDocuments.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addMeasureToProjectStageMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Measures_MeasureEntityId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_MeasureEntityId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MeasureEntityId",
                table: "Materials");

            migrationBuilder.AddColumn<Guid>(
                name: "MeasureId",
                table: "ProjectStageMaterials",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStageMaterials_MeasureId",
                table: "ProjectStageMaterials",
                column: "MeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStageMaterials_Measures_MeasureId",
                table: "ProjectStageMaterials",
                column: "MeasureId",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStageMaterials_Measures_MeasureId",
                table: "ProjectStageMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ProjectStageMaterials_MeasureId",
                table: "ProjectStageMaterials");

            migrationBuilder.DropColumn(
                name: "MeasureId",
                table: "ProjectStageMaterials");

            migrationBuilder.AddColumn<Guid>(
                name: "MeasureEntityId",
                table: "Materials",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MeasureEntityId",
                table: "Materials",
                column: "MeasureEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Measures_MeasureEntityId",
                table: "Materials",
                column: "MeasureEntityId",
                principalTable: "Measures",
                principalColumn: "Id");
        }
    }
}
