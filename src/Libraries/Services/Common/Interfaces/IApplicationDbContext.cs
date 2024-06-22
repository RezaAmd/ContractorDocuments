using Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace BuildingMaterialAccounting.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<UserEntity> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}