namespace ContractorDocuments.Application.Projects.ViewModels
{
    public class BoardViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal TotalExpense { get; set; }
        public IList<BoardStageViewModel> Stages { get; set; }
    }
}