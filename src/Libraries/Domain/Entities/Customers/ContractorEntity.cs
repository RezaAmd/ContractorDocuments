namespace ContractorDocuments.Domain.Entities.Customers
{
    public class ContractorEntity : BaseEntity
    {
        public required string Name { get; set; }

        #region Relations

        public virtual ICollection<ContractorSpecialtyEntity>? Specialties { get; private set; }

        #endregion
    }
}