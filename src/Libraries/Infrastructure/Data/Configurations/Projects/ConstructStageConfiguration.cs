using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Projects
{
    internal class ConstructStageConfiguration : IEntityTypeConfiguration<ConstructStageEntity>
    {
        public void Configure(EntityTypeBuilder<ConstructStageEntity> builder)
        {
            builder.ToTable("ConstructStages");

            // Name
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);

            // ProjectTypeId
            builder.Property(e => e.ProjectTypeId)
                .HasColumnType("tinyint");

            // Display Order
            builder.Property(e => e.DisplayOrder)
                .IsRequired()
                .HasDefaultValue(0);

            #region Relations

            // ProjectStages
            builder.HasMany(e => e.ProjectStages)
                .WithOne(p => p.ConstructStage)
                .HasForeignKey(p => p.ConstructStageId);

            #endregion
        }
    }
}