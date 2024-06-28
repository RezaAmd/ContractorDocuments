using ContractorDocuments.Domain.Entities.Equipment;

namespace ContractorDocuments.Domain.Entities.Projects
{
    public class ProjectStageEntity : BaseEntity
    {
        public required Guid ProjectId { get; set; } // Foreign Key
        public required Guid ConstructStageId { get; set; } // Foreign Key

        #region Relations

        public virtual ProjectEntity? Project { get; private set; }
        public virtual ConstructStageEntity? ConstructStage { get; private set; }
        public virtual ICollection<ProjectStageEquipmentEntity>? Equipment { get; private set; }
        public virtual ICollection<ProjectStageMaterialEntity>? Supplies { get; private set; }

        #endregion
    }
}