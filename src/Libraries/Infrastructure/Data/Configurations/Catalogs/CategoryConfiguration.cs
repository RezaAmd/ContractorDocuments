using ContractorDocuments.Domain.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Catalogs
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Categories");

            // Id
            builder.HasKey(c => c.Id);

            // Name
            builder.Property(c => c.Name)
                .HasMaxLength(50);

            // RelevantEntityTypeId
            builder.Property(c => c.RelevantEntityTypeId);

            // ParentId
            builder.Property(c => c.ParentId)
                .IsRequired(false);

            #region Relations
            // Parent
            builder.HasOne(c => c.Parent)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentId);

            // Materials
            builder.HasMany(c => c.Materials)
                .WithOne(m => m.Category)
                .HasForeignKey(m => m.CategoryId);

            // Equipments
            builder.HasMany(c => c.Equipments)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId);

            #endregion
        }
    }
}
