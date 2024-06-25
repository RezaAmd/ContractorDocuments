using BuildingMaterialAccounting.Application.Common.Interfaces;
using BuildingMaterialAccounting.Domain.Entities.Customers;
using BuildingMaterialAccounting.Domain.Entities.Projects;
using System.Reflection;

namespace BuildingMaterialAccounting.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region Tables

        #region Customers

        public DbSet<UserEntity> Users => Set<UserEntity>();

        #endregion

        #region Projects

        public DbSet<ProjectEntity> Projects => Set<ProjectEntity>();

        #endregion

        #endregion

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}