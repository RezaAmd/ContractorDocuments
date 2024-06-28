using ContractorDocuments.Domain.Entities.Materials;

namespace ContractorDocuments.Domain.Entities.Projects
{
    /// <summary>
    /// Material for project stage.
    /// </summary>
    public class ProjectStageMaterialEntity : BaseEntity
    {
        public required Guid MaterialId { get; set; } // Foreign Key
        public required Guid ProjectStepId { get; set; } // Foreign Key
        public required decimal Amount { get; set; }
        public required decimal UnitPrice { get; set; }
        public decimal? TotalNetProfit { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        #region Relations

        public virtual MaterialEntity? MaterialMeasurementUnit { get; private set; }
        public virtual ProjectStageEntity? ProjectStep { get; private set; }

        #endregion

        #region Ctor

        #endregion
    }
}