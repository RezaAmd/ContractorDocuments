using ContractorDocuments.Domain.Entities.Equipment;

namespace ContractorDocuments.Domain.Entities.Projects
{
    /// <summary>
    /// Map between Equipment & ProjectStage.
    /// </summary>
    public class ProjectStageEquipmentEntity : BaseEntity
    {
        public required Guid EquipmentId { get; set; }
        public required Guid ProjectStageId { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        #region Relations

        public virtual EquipmentEntity? Equipment { get; private set; }
        public virtual ProjectStageEntity? ProjectStage { get; private set; }

        #endregion
    }
}