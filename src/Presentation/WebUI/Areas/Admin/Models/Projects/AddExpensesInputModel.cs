namespace ContractorDocuments.WebUI.Areas.Admin.Models.Projects
{
    public record AddExpensesInputModel(string ProjectStageId, string Title, decimal Amount, string PaidOn, string Description);
}