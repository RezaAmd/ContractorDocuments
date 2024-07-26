using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Projects
{
    internal class ProjectStageMaterialConfiguration : IEntityTypeConfiguration<ProjectStageMaterialEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectStageMaterialEntity> builder)
        {
            builder.ToTable("ProjectStageMaterials");

            // Amount
            builder.Property(b => b.Amount);

            // UnitPrice
            builder.Property(b => b.UnitPrice);

            // TotalNetProfit
            builder.Property(b => b.TotalNetProfit)
                .IsRequired();

            // CreatedOn
            builder.Property(b => b.CreatedOn);

            #region Relations

            // Material
            builder.HasOne(b => b.Material)
                .WithMany(m => m.ProjectStageMaterials)
                .HasForeignKey(b => b.MaterialId);

            // ProjectStage
            builder.HasOne(b => b.ProjectStep)
                .WithMany(ps => ps.Materials)
                .HasForeignKey(b => b.ProjectStepId);

            #endregion
        }
    }
}