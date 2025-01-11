namespace ContractorDocuments.Domain.Entities.Invoices
{
    public class InvoiceItemEntity : BaseEntity
    {
        public Guid InvoiceEntity { get; set; }
        public required string Description { get; set; } // Item Description
        public required int Quantity { get; set; } // Quantity
        public required decimal UnitPrice { get; set; } // Unit Price

        public virtual InvoiceEntity? Invoice { get; set; }
    }
}