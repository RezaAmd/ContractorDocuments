using ContractorDocuments.Domain.Entities.Directory;
using ContractorDocuments.Domain.Entities.Resources;

namespace ContractorDocuments.Domain.Entities.Projects
{
    /// <summary>
    /// Material for project stage.
    /// </summary>
    public class ProjectStageMaterialEntity : BaseEntity, IDateTimeCreation
    {
        public required decimal Amount { get; set; }
        public decimal? TotalNetProfit { get; set; }
        public decimal? TransportCost { get; set; }
        public DateTime? PurchacedOn { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        #region Relations

        public required Guid MaterialId { get; set; } // Foreign Key
        public virtual MaterialEntity? Material { get; private set; }

        public required Guid ProjectStepId { get; set; } // Foreign Key
        public virtual ProjectStageEntity? ProjectStage { get; private set; }

        public required Guid MeasureId { get; set; } // FK
        public virtual MeasureEntity? Measure { get; set; }

        public Guid? ExpenseId { get; set; } // FK
        public virtual ProjectStageExpenseEntity? Expense { get; set; }

        #endregion
    }
}