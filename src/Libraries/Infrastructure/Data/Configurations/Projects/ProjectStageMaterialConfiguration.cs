using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Projects
{
    internal class ProjectStageMaterialConfiguration : IEntityTypeConfiguration<ProjectStageMaterialEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectStageMaterialEntity> builder)
        {
            builder.ToTable("ProjectStageMaterials");

            // Amount
            builder.Property(b => b.Amount)
                .HasPrecision(18, 2);

            // UnitPrice
            builder.Property(b => b.UnitPrice)
                .HasPrecision(18, 2);

            // TotalNetProfit
            builder.Property(b => b.TotalNetProfit)
                .HasPrecision(18, 2)
                .IsRequired();

            // TransportCost
            builder.Property(b => b.TransportCost)
                .HasPrecision(18, 2)
                .IsRequired(false);

            // PurchacedOn
            builder.Property(b => b.PurchacedOn)
                .IsRequired(false);

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