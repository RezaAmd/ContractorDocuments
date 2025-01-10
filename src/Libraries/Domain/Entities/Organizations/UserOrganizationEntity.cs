using ContractorDocuments.Domain.Entities.Customers;

namespace ContractorDocuments.Domain.Entities.Organizations
{
    public class UserOrganizationEntity : BaseEntity
    {
        public Guid OrganizationId { get; set; }
        public Guid UserId { get; set; }
        public string? Role { get; set; }

        public virtual OrganizationEntity? Organization { get; set; }
        public virtual UserEntity? User { get; set; }
    }
}