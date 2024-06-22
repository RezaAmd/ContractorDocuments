using BuildingMaterialAccounting.Core.Domain.Customers;
using System.Reflection;

namespace BuildingMaterialAccounting.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
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