
using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Domain.Entities.Invoices
{
    public class InvoiceEntity : BaseEntity, IDateTimeCreation
    {
        public required Guid ProjectId { get; set; } // Link to the Project
        public required string InvoiceNumber { get; set; } // Unique Identifier
        public DateTime IssuedOn { get; set; } // Date of Issue
        public DateTime? DueDate { get; set; } // Payment Due Date
        public decimal TotalAmount { get; set; } // Total Invoice Amount
        public decimal? PaidAmount { get; set; } // Amount Already Paid
        public InvoiceStatus StatusId { get; set; } = InvoiceStatus.Pending; // Enum for Invoice Status
        public string? Notes { get; set; } // Additional Notes
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        public virtual ProjectEntity? Project { get; set; }
    }
}