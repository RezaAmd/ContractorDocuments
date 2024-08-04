namespace ContractorDocuments.WebUI.Areas.Admin.Models.Projects
{
    public class CreateStageMaterialInputModel
    {
        public string StageId { get; set; }
        public string MaterialId { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public string? PurchasedOn { get; set; }
        public decimal? TransportCost { get; set; }
        public decimal? TotalNetProfit { get; set; }
    }
}