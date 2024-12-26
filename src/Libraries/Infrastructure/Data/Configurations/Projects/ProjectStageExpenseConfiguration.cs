using ContractorDocuments.Domain.Entities.Projects;
using ContractorDocuments.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Projects
{
    internal class ProjectStageExpenseConfiguration : IEntityTypeConfiguration<ProjectStageExpenseEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectStageExpenseEntity> builder)
        {
            builder.ToTable("ProjectStageExpenses");

            // Title
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(80);

            // Amount
            builder.Property(b => b.Amount)
                .HasPrecision(18, 2);

            // TypeId
            builder.Property(b => b.TypeId)
                .HasDefaultValue(ExpenseType.Other)
                .HasColumnType("tinyint");

            // PaidOn
            builder.Property(b => b.PaidOn);

            // Description
            builder.Property(b => b.Description)
                .HasMaxLength(256);

            #region Relations

            // ProjectStage
            builder.HasOne(b => b.ProjectStage)
                .WithMany(b => b.Expenses)
                .HasForeignKey(b => b.ProjectStageId);

            #endregion
        }
    }
}
