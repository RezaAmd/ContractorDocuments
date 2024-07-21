using ContractorDocuments.Domain.Entities.Materials;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Materials
{
    internal class MaterialConfiguration : IEntityTypeConfiguration<MaterialEntity>
    {
        public void Configure(EntityTypeBuilder<MaterialEntity> builder)
        {
            builder.ToTable("Materials");

            // Name
            builder.Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();

            #region Relations

            // ParentMaterial
            builder.HasOne(b => b.ParentMaterial)
                .WithMany(b => b.ChildrenMaterial)
                .HasForeignKey(b => b.ParentMaterialId);

            // ChildrenMaterial
            builder.HasMany(b => b.ChildrenMaterial)
                .WithOne(b => b.ParentMaterial)
                .HasForeignKey(b => b.ParentMaterialId);

            // Measure
            builder.HasOne(b => b.Measure)
                .WithMany(m => m.Materials)
                .HasForeignKey(b => b.MeasureId);

            #endregion
        }
    }
}