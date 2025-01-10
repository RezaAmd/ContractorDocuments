using ContractorDocuments.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractorDocuments.Domain.Entities.Organizations
{
    public class OrganizationEntity : BaseEntity, IDateTimeCreation
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public Guid OwnerUserId { get; set; }

        public virtual UserEntity? Owner { get; set; }

    }
}