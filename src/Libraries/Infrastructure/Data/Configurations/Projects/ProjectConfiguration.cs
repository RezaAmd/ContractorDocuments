using ContractorDocuments.Domain.Entities.Customers;
using ContractorDocuments.Domain.Entities.Projects;
using ContractorDocuments.Domain.Enums;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Customers
{
    public class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
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
            b.Property(e => e.ProcessStatusTypeId);

            // StartOn
            b.Property(e => e.StartOn)
                .IsRequired(false);

            // EndOn
            b.Property(e => e.EndOn)
                .IsRequired(false);

            // Description
            b.Property(e => e.Description)
                .IsRequired(false);

            // CreatedOn
            b.Property(e => e.CreatedOn)
                .ValueGeneratedOnAdd()
                .IsRequired();

            #region Relations

            // Contract
            b.HasOne(p => p.Contract)
                .WithOne(c => c.Project)
                .HasForeignKey<ProjectContractEntity>(pc => pc.ProjectId);

            #endregion
        }
    }
}