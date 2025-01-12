namespace ContractorDocuments.Domain.Entities.Projects
{
    public class ProjectStageExpenseEntity : BaseEntity, IDateTimeCreation
    {
        public decimal Amount { get; set; }
        public string Title { get; set; } = string.Empty;
        public ExpenseType TypeId { get; set; }
        public DateTime PaidOn { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        #region Relations
        public Guid ProjectStageId { get; set; } // FK
        public virtual ProjectStageEntity? ProjectStage { get; private set; }
        #endregion

        #region Ctor
        ProjectStageExpenseEntity() { }
        public ProjectStageExpenseEntity(string title, decimal amount,
            ExpenseType expenseTypeId, DateTime paidOn, Guid projectId)
        {
            Title = title;
            Amount = amount;
            PaidOn = paidOn;
            TypeId = expenseTypeId;
        }
        #endregion
    }
}