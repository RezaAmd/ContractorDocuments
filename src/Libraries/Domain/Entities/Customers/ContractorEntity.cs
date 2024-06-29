namespace ContractorDocuments.Domain.Entities.Customers
{
    public class ContractorEntity : BaseEntity
    {
        public required string Name { get; set; }
        public string? PhoneNumber { get; set; }

        #region Relations

        public virtual ICollection<ContractorSpecialtyEntity>? Specialties { get; private set; }

        #endregion
    }
}