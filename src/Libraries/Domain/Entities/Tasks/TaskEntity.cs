using ContractorDocuments.Domain.Entities.Customers;
using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Domain.Entities.Tasks
{
    public class TaskEntity : BaseEntity, IDateTimeCreation
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public PriorityLevel PriorityLevelId { get; set; } = PriorityLevel.Medium;
        public TaskStatus StatusId { get; set; } = TaskStatus.NotStarted;
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        #region Relations
        public Guid OwnerId { get; set; }
        public virtual UserEntity? User { get; set; }

        public Guid ProjectId { get; set; }
        public virtual ProjectEntity? Project { get; set; }

        public Guid? ProjectStageId { get; set; }
        public virtual ProjectStageEntity? ProjectStage { get; set; }

        public virtual ICollection<ChecklistEntity>? CheckLists { get; set; }
        #endregion

        #region Ctor
        TaskEntity() { }
        public TaskEntity(string title, Guid ownerId, Guid projectId, Guid? projectStageId)
        {
            Title = title;
            OwnerId = ownerId;
            ProjectId = projectId;

            if (projectStageId != null || projectStageId != Guid.Empty)
            {
                ProjectStageId = projectStageId;
            }
        }
        #endregion
    }
}