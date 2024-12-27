using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractorDocuments.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationToStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExpenseId",
                table: "ProjectStageMaterials",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExpenseId",
                table: "ProjectStageEquipments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStageMaterials_ExpenseId",
                table: "ProjectStageMaterials",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStageEquipments_ExpenseId",
                table: "ProjectStageEquipments",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStageEquipments_ProjectStageExpenses_ExpenseId",
                table: "ProjectStageEquipments",
                column: "ExpenseId",
                principalTable: "ProjectStageExpenses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStageMaterials_ProjectStageExpenses_ExpenseId",
                table: "ProjectStageMaterials",
                column: "ExpenseId",
                principalTable: "ProjectStageExpenses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStageEquipments_ProjectStageExpenses_ExpenseId",
                table: "ProjectStageEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStageMaterials_ProjectStageExpenses_ExpenseId",
                table: "ProjectStageMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ProjectStageMaterials_ExpenseId",
                table: "ProjectStageMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ProjectStageEquipments_ExpenseId",
                table: "ProjectStageEquipments");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "ProjectStageMaterials");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "ProjectStageEquipments");
        }
    }
}
