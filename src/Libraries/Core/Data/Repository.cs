using BuildingMaterialAccounting.Core.Domain;

namespace BuildingMaterialAccounting.Infrastructure.Data
{
    public class Repository<TEntity> where TEntity : BaseEntity
    {
        public IQueryable<TEntity> Table { get; }
    }
}