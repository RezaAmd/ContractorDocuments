namespace ContractorDocuments.Domain.Entities.Projects
{
    public class ProjectStageExpenseEntity : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime PaidOn { get; set; }
        public string? Description { get; set; }
        public Guid ProjectStageId { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        #region Relations

        public virtual ProjectStageEntity? ProjectStage { get; set; }

        #endregion


        #region Ctor

        ProjectStageExpenseEntity() { }
        public ProjectStageExpenseEntity(string title, decimal amount, DateTime paidOn, Guid projectStageId)
        {
            Title = title;
            Amount = amount;
            PaidOn = paidOn;
            ProjectStageId = projectStageId;
        }

        #endregion
    }
}