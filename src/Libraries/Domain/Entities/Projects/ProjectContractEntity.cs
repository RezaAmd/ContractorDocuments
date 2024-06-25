namespace ContractorDocuments.Domain.Entities.Projects
{
    public class ProjectContractEntity : BaseEntity
    {
        public required ProjectContractType ContractTypeId { get; set; }
        public decimal Amount { get; set; }
        public byte Percentage { get; set; }
        public required Guid ProjectId { get; set; }

        #region Relations

        public virtual ProjectEntity? Project { get; set; }

        #endregion
    }
}
