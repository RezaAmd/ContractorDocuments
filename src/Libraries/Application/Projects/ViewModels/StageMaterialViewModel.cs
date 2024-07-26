namespace ContractorDocuments.Application.Projects.ViewModels
{
    public record StageMaterialViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? TotalNetProfit { get; set; }
    }
}