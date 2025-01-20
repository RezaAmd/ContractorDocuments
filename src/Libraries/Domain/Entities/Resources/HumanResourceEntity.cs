namespace ContractorDocuments.Domain.Entities.Resources
{
    public class HumanResourceEntity : BaseEntity
    {
        public required Fullname Fullname { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }

        public Guid? OrganizationId { get; set; }
    }
}