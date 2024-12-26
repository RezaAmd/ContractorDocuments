namespace ContractorDocuments.Domain.Entities.Projects
{
    public class TransportEntity : BaseEntity, IDateTimeCreation
    {
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public Guid ExpenseId { get; set; }
        public ProjectStageExpenseEntity? Expense { get; set; }
    }
}