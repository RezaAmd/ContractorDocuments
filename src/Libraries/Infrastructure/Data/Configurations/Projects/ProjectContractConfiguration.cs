using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Projects
{
    internal class ProjectContractConfiguration : IEntityTypeConfiguration<ProjectContractEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectContractEntity> builder)
        {
            builder.ToTable("ProjectContracts");

            // ContractTypeId
            builder.Property(e => e.ContractTypeId)
                .IsRequired();

            // Amount
            builder.Property(e => e.Amount)
                .HasColumnType("DECIMAL(16,2)")
                .HasDefaultValue(0);

            // Percentage
            builder.Property(e => e.SharePercentage)
                .HasDefaultValue(0);

            // ProjectId
            builder.Property(e => e.ProjectId)
                .IsRequired();

            #region Relations

            // Project
            builder.HasOne(pc => pc.Project)
                .WithOne(p => p.Contract)
                .HasForeignKey<ProjectEntity>(p => p.ContractId);

            #endregion

        }
    }
}