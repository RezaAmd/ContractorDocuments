using ContractorDocuments.Domain.Entities.Directory;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Directories
{
    internal class MeasureConfiguration : IEntityTypeConfiguration<MeasureEntity>
    {
        public void Configure(EntityTypeBuilder<MeasureEntity> builder)
        {
            builder.ToTable("Measures");

            // Name
            builder.Property(m => m.Name)
                .HasMaxLength(50)
                .IsRequired();

            // SystemKeyword
            builder.Property(m => m.SystemKeyword)
                .HasMaxLength(20)
                .IsRequired();

            #region Relations

            // ProjectStageMaterials
            builder.HasMany(m => m.ProjectStageMaterials)
                .WithOne(psm => psm.Measure)
                .HasForeignKey(psm => psm.MeasureId);

            #endregion
        }
    }
}