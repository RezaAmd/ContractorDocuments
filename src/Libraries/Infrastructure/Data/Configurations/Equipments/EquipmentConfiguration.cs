﻿using ContractorDocuments.Domain.Entities.Equipment;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Equipments
{
    internal class EquipmentConfiguration : IEntityTypeConfiguration<EquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<EquipmentEntity> builder)
        {
            builder.ToTable("Equipments");

            // Name
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            #region Relations

            // ProjectStageEquipments
            builder.HasMany(b => b.ProjectStageEquipments)
                .WithOne(pse => pse.Equipment)
                .HasForeignKey(pse => pse.EquipmentId);

            #endregion
        }
    }
}