
namespace ContractorDocuments.Domain.Entities.Invoices
{
    public class InvoiceEntity : BaseEntity, IDateTimeCreation
    {
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
    }
}