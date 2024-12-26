using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractorDocuments.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelateAllToExpense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "ProjectStageMaterials");

            migrationBuilder.AddColumn<byte>(
                name: "TypeId",
                table: "ProjectStageExpenses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "ProjectStageExpenses");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "ProjectStageMaterials",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
