using BuildingMaterialAccounting.Domain.Entities.Customers;
using BuildingMaterialAccounting.Domain.Entities.Projects;

namespace BuildingMaterialAccounting.Application.Common.Interfaces
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