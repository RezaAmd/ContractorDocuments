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

        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}