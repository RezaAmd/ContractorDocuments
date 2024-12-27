using ContractorDocuments.Domain.Entities.Equipment;

namespace ContractorDocuments.Domain.Entities.Projects
{
    /// <summary>
    /// Map between Equipment & ProjectStage.
    /// </summary>
    public class ProjectStageEquipmentEntity : BaseEntity, IDateTimeCreation
    {
        public Guid ProjectStageId { get; private set; }
        public Guid EquipmentId { get; private set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsRent { get; set; }
        public DateTime? RentStartTime { get; set; }
        public DateTime? RentEndTime { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;
        public string? Description { get; set; }
        public Guid? ExpenseId { get; set; }

        #region Relations
        public virtual EquipmentEntity? Equipment { get; private set; }
        public virtual ProjectStageEntity? ProjectStage { get; private set; }
        public virtual ProjectStageExpenseEntity? Expense { get; set; }
        #endregion

        #region Ctor
        public ProjectStageEquipmentEntity(int quantity, decimal totalCost, Guid projectStageId, Guid equipmentId)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException("Quantity cannot less than 1.");
            Quantity = quantity;

            if (totalCost < 0)
                throw new ArgumentOutOfRangeException("Total cost cannot less than 0.");
            TotalCost = totalCost;

            if (projectStageId == Guid.Empty)
                throw new ArgumentNullException("Project stage id cannot be null or empty.");
            ProjectStageId = projectStageId;

            if (equipmentId == Guid.Empty)
                throw new ArgumentNullException("Project stage id cannot be null or empty.");
            EquipmentId = equipmentId;
        }
        #endregion
    }
}