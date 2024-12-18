using ContractorDocuments.Domain.Entities.Directory;
using ContractorDocuments.Domain.Entities.Materials;

namespace ContractorDocuments.Domain.Entities.Projects
{
    /// <summary>
    /// Material for project stage.
    /// </summary>
    public class ProjectStageMaterialEntity : BaseEntity, IDateTimeCreation
    {
        public required decimal Amount { get; set; }
        public required decimal UnitPrice { get; set; }
        public decimal? TotalNetProfit { get; set; }
        public decimal? TransportCost { get; set; }
        public DateTime? PurchacedOn { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;
        public required Guid MaterialId { get; set; } // Foreign Key
        public required Guid ProjectStepId { get; set; } // Foreign Key
        public required Guid MeasureId { get; set; } // FK

        #region Relations

        public virtual MaterialEntity? Material { get; private set; }
        public virtual ProjectStageEntity? ProjectStep { get; private set; }
        public virtual MeasureEntity? Measure { get; set; }

        #endregion
    }
}