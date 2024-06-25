namespace ContractorDocuments.Domain.Entities.Directory
{
    public class CurrencyEntity
    {
        public required string Name { get; set; }
        public required string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;
    }
}