namespace ContractorDocuments.Application.Projects.ViewModels
{
    public class StageExpenseViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public string PaidOn { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}