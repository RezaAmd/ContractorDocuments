using ContractorDocuments.Application.Common.Interfaces;
using ContractorDocuments.Domain.Entities.Customers;
using ContractorDocuments.Domain.Entities.Projects;
using System.Reflection;

namespace ContractorDocuments.Infrastructure.Data
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

        public async Task<Result> SaveChangeAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            if (Convert.ToBoolean(await SaveChangesAsync(cancellationToken)))
                return Result.Ok();
            return Result.Fail();
        }

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