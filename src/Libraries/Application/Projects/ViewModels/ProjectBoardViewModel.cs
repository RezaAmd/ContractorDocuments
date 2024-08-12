namespace ContractorDocuments.Application.Projects.ViewModels
{
    public class BoardViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public decimal TotalExpense { get; set; }
        public IList<BoardStageViewModel> Stages { get; set; } = [];
    }
}