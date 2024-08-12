namespace ContractorDocuments.Application.Projects.ViewModels
{
    public record StageMaterialViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public decimal UnitPrice { get; set; } = 0;
        public string? PurchasedOn { get; set; }
        public decimal? TransportCost { get; set; }
        public decimal? TotalNetProfit { get; set; }
        public decimal TotalCost { get; set; } = 0;
    }
}