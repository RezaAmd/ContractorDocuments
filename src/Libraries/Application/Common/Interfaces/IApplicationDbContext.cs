using ContractorDocuments.Domain.Entities.Customers;
using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        #region Customers

        DbSet<UserEntity> Users { get; }

        #endregion

        #region Projects

        DbSet<ProjectEntity> Projects { get; }
        DbSet<ProjectStageEntity> ProjectStages { get; }

        #endregion

        #region Basic Data

        DbSet<ConstructStageEntity> ConstructStages { get; }

        #endregion

        Task<Result> SaveChangeAsync(CancellationToken cancellationToken);
    }
}