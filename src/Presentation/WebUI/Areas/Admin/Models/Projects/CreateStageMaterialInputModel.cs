namespace ContractorDocuments.WebUI.Areas.Admin.Models.Projects
{
    public class CreateStageMaterialInputModel
    {
        public string StageId { get; set; } = string.Empty;
        public string MaterialId { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public decimal UnitPrice { get; set; } = 0;
        public string? PurchasedOn { get; set; }
        public decimal? TransportCost { get; set; }
        public decimal? TotalNetProfit { get; set; }
    }
}