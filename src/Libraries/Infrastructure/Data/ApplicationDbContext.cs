using ContractorDocuments.Application.Common.Interfaces;
using ContractorDocuments.Application.Common.Models;
using ContractorDocuments.Domain.Entities.Customers;
using ContractorDocuments.Domain.Entities.Directory;
using ContractorDocuments.Domain.Entities.Materials;
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
        public DbSet<ProjectStageEntity> ProjectStages => Set<ProjectStageEntity>();
        public DbSet<ConstructStageEntity> ConstructStages => Set<ConstructStageEntity>();
        public DbSet<ProjectStageMaterialEntity> ProjectStageMaterials => Set<ProjectStageMaterialEntity>();

        #endregion

        #region Materials

        public DbSet<MaterialEntity> Materials => Set<MaterialEntity>();


        #endregion

        #region Directory

        public DbSet<MeasureEntity> Measures => Set<MeasureEntity>();

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