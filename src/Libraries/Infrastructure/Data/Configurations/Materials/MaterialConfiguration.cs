using ContractorDocuments.Domain.Entities.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // 

            #endregion
        }
    }
}
