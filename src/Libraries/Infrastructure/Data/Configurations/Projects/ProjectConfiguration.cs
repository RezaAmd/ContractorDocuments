using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Projects
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> b)
        {
            b.ToTable("Projects");

            // Title
            b.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

            // ProjectTypeId
            b.Property(e => e.ProjectTypeId)
                .IsRequired()
                .HasMaxLength(100);

            // ContractId
            b.Property(e => e.ContractId)
                .IsRequired()
                .HasMaxLength(15);

            // ProcessStatusTypeId
            //b.Property(e => e.ProcessStatusTypeId);

            // StartOn
            b.Property(e => e.StartOn)
                .IsRequired(false);

            // EndOn
            b.Property(e => e.EndOn)
                .IsRequired(false);

            // Description
            b.Property(e => e.Description)
                .IsRequired(false)
                .HasMaxLength(1000);

            // CreatedOn
            b.Property(e => e.CreatedOn)
                .ValueGeneratedOnAdd()
                .IsRequired();

            // Latitude
            b.Property(b => b.Latitude)
                .HasColumnType("DECIMAL(9, 6)")
                .IsRequired(false);

            // Longitude
            b.Property(b => b.Longitude)
                .HasColumnType("DECIMAL(9, 6)")
                .IsRequired(false);

            #region Relations

            // Contract
            b.HasOne(p => p.Contract)
                .WithOne(c => c.Project)
                .HasForeignKey<ProjectContractEntity>(pc => pc.ProjectId);

            #endregion
        }
    }
}