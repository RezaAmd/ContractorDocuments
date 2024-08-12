namespace ContractorDocuments.Application.Projects.ViewModels
{
    public class BoardStageViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal TotalExpense { get; set; }
        public IList<StageMaterialViewModel> Materials { get; set; } = [];
    }
}