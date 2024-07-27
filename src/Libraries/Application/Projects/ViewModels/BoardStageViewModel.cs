namespace ContractorDocuments.Application.Projects.ViewModels
{
    public class BoardStageViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal TotalExpense { get; set; }
        public IList<StageMaterialViewModel> Materials { get; set; }
    }
}