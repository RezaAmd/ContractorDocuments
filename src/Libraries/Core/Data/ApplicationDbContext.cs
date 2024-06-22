using BuildingMaterialAccounting.Application.Common.Interfaces;
using BuildingMaterialAccounting.Domain.Entities.Customers;
using System.Reflection;

namespace BuildingMaterialAccounting.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region Tables

        public DbSet<UserEntity> Users => Set<UserEntity>();

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}