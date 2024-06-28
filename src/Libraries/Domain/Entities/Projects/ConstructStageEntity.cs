namespace ContractorDocuments.Domain.Entities.Projects
{
    public class ConstructStageEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required ProjectType ProjectTypeId { get; set; }
        public byte DisplayOrder { get; set; }

        #region Relations

        public virtual ICollection<ProjectStageEntity>? ProjectStages { get; private set; }

        #endregion
    }
}