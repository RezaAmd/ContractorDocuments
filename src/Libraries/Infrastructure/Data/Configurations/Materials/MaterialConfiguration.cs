using ContractorDocuments.Domain.Entities.Resources;

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

            // CategoryId
            builder.Property(b => b.CategoryId);

            #region Relations

            // Category
            builder.HasOne(m => m.Category)
                .WithMany(m => m.Materials)
                .HasForeignKey(b => b.CategoryId);

            #endregion
        }
    }
}