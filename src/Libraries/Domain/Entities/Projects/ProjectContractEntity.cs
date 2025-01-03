﻿namespace ContractorDocuments.Domain.Entities.Projects
{
    public class ProjectContractEntity : BaseEntity
    {
        public required ProjectContractType ContractTypeId { get; set; }
        public decimal Amount { get; set; }
        public byte SharePercentage { get; set; }
        public Guid ProjectId { get; set; } // Foreign Key

        #region Relations

        public virtual ProjectEntity? Project { get; private set; }

        #endregion
    }
}
