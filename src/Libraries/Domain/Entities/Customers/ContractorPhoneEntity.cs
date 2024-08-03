namespace ContractorDocuments.Domain.Entities.Customers
{
    public class ContractorPhoneEntity : BaseEntity
    {
        public required string PhoneNumber { get; set; }
        public required Guid ContractorId { get; set; }

        #region Relations

        public virtual ContractorEntity? Contractor { get; set; }

        #endregion
    }
}