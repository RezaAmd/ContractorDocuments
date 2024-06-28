using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Infrastructure.Data.Configurations.Projects
{
    internal class ProjectStageConfiguration : IEntityTypeConfiguration<ProjectStageEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectStageEntity> builder)
        {
            builder.ToTable("ProjectStages");

            // ProjectId - FK
            builder.Property(b => b.ProjectId);

            // ConstructStageId - FK
            builder.Property(b => b.ConstructStageId);

            #region Relations

            // Project
            builder.HasOne(e => e.Project)
                .WithMany(cs => cs.ConstructStages)
                .HasForeignKey(e => e.ProjectId);

            // ConstructStage
            builder.HasOne(e => e.ConstructStage)
                .WithMany(cs => cs.ProjectStages)
                .HasForeignKey(e => e.ConstructStageId);

            // Equipment

            // Supplies

            #endregion
        }
    }
}