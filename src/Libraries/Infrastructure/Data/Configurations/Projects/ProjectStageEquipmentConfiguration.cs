using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Projects
{
    internal class ProjectStageEquipmentConfiguration : IEntityTypeConfiguration<ProjectStageEquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectStageEquipmentEntity> builder)
        {
            builder.ToTable("ProjectStageEquipments");

            // Quantity
            builder.Property(b => b.Quantity)
                .HasDefaultValue(1);

            // TotalCost
            builder.Property(b => b.TotalCost)
                .HasPrecision(18, 2)
                .HasDefaultValue(0);

            // IsRent
            builder.Property(b => b.IsRent);

            // RentStartTime
            builder.Property(b => b.RentStartTime)
                .IsRequired(false);

            // RentEndTime
            builder.Property(b => b.RentEndTime)
                .IsRequired(false);

            // CreatedOn
            builder.Property(b => b.CreatedOn)
                .ValueGeneratedOnAdd();

            // Description
            builder.Property(b => b.Description)
                .IsRequired(false)
                .HasMaxLength(256);

            #region Relations

            // ProjectStageId
            builder.Property(b => b.ProjectStageId)
                .IsRequired();
            // ProjectStage
            builder.HasOne(b => b.ProjectStage)
                .WithMany(ps => ps.Equipments)
                .HasForeignKey(b => b.ProjectStageId);

            // EquipmentId
            builder.Property(b => b.EquipmentId)
                .IsRequired();
            // Equipment
            builder.HasOne(b => b.Equipment)
                .WithMany(e => e.ProjectStageEquipments)
                .HasForeignKey(b => b.EquipmentId);

            #endregion
        }
    }
}
