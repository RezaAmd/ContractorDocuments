namespace ContractorDocuments.Domain.Entities.Customers
{
    public class ContractorEntity : BaseEntity
    {
        public Fullname? Fullname { get; set; }
        public string? Email { get; set; }

        // Organization
        public string? CompanyName { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        #region Relations
        public virtual ICollection<ContractorPhoneEntity>? Phones { get; private set; }
        #endregion
    }
}