namespace ContractorDocuments.Domain.Entities.Projects
{
    public class ProjectEntity : BaseEntity, IDateTimeCreation
    {
        public required string Title { get; set; }
        public required ProjectType ProjectTypeId { get; set; } = ProjectType.Construction;
        public required Guid ContractId { get; set; }
        //public ProjectProcessStatusType ProcessStatusTypeId { get; set; } = ProjectProcessStatusType.InProgress;
        public DateTime? StartOn { get; set; }
        public DateTime? EndOn { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        #region Relations

        public required virtual ProjectContractEntity Contract { get; set; }
        public virtual ICollection<ProjectStageEntity>? Stages { get; private set; }

        #endregion

        #region Ctor



        #endregion
    }
}