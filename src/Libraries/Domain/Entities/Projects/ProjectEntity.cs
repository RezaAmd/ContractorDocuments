namespace BuildingMaterialAccounting.Domain.Entities.Projects
{
    public class ProjectEntity : BaseEntity
    {
        public required string Title { get; set; }
        public required ProjectType ProjectTypeId { get; set; } = ProjectType.Construction;
        public required ProjectContractType ContractTypeId { get; set; } = ProjectContractType.Personal;
        public ProjectProcessStatusType ProcessStatusTypeId { get; set; } = ProjectProcessStatusType.InProgress;
        public DateTime? StartOn { get; set; }
        public DateTime? EndOn { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        #region Relations



        #endregion

        #region Ctor



        #endregion
    }
}