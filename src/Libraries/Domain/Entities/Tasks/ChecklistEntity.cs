using ContractorDocuments.Domain.Entities.Customers;

namespace ContractorDocuments.Domain.Entities.Tasks
{
    public class ChecklistEntity : BaseEntity, IDateTimeCreation
    {
        public required string Title { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        #region Relations
        public Guid OwnerId { get; set; }
        public virtual UserEntity? User { get; set; }

        public Guid TaskId { get; set; }
        public virtual TaskEntity? Task { get; set; }
        #endregion
    }
}
