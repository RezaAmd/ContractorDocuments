namespace ContractorDocuments.WebUI.Areas.Admin.Models.Projects
{
    public class ProjectBoardViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal TotalCost { get; set; }
        public List<ProjectConstructStageViewModel>? ConstructionStages { get; set; }
        public List<SelectListItem>? ConstructionStagesCanBeAdded { get; set; }
    }

    public class ProjectConstructStageViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
        public int DisplayOrder { get; set; }
        public IList<ProjectConstructStageMaterialViewModel> Materials { get; set; }

    }

    public record ProjectConstructStageMaterialViewModel
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? TotalNetProfit { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}