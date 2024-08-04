namespace ContractorDocuments.Application.Projects.ViewModels
{
    public record StageMaterialViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public string? PurchasedOn { get; set; }
        public decimal? TransportCost { get; set; }
        public decimal? TotalNetProfit { get; set; }
        public decimal TotalCost { get; set; } = 0;
    }
}