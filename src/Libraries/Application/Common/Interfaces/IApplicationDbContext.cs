using ContractorDocuments.Domain.Entities.Catalogs;
using ContractorDocuments.Domain.Entities.Customers;
using ContractorDocuments.Domain.Entities.Directory;
using ContractorDocuments.Domain.Entities.Equipment;
using ContractorDocuments.Domain.Entities.Materials;
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
        DbSet<ProjectStageEntity> ProjectStages { get; }
        DbSet<ConstructStageEntity> ConstructStages { get; }
        DbSet<ProjectStageMaterialEntity> ProjectStageMaterials { get; }
        DbSet<ProjectStageExpenseEntity> ProjectStageExpenses { get; }
        DbSet<ProjectStageEquipmentEntity> ProjectStageEquipments { get; }

        #endregion

        #region Catalog

        DbSet<CategoryEntity> Categories { get; }

        #endregion

        #region Materials

        DbSet<MaterialEntity> Materials { get; }

        #endregion

        #region Equipments

        DbSet<EquipmentEntity> Equipments { get; }

        #endregion

        #region Directory

        DbSet<MeasureEntity> Measures { get; }

        #endregion

        Task<Result> SaveChangeAsync(CancellationToken cancellationToken);
    }
}