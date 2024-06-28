namespace ContractorDocuments.Domain.Entities.Customers
{
    public class ContractorSpecialtyEntity : BaseEntity
    {
        public required ContractorSpeciallyType SpecialityTypeId { get; set; }
        public required Guid ContractorId { get; set; }

        #region Relations

        public virtual ContractorEntity? Contractor { get; private set; }

        #endregion
    }
}