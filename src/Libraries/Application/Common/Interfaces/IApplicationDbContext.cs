using BuildingMaterialAccounting.Domain.Entities.Customers;

namespace BuildingMaterialAccounting.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<UserEntity> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}