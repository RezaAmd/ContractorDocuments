namespace ContractorDocuments.Domain.Entities.Projects
{
    public class ProjectStageTaskEntity : BaseEntity
    {
        public string Title { get; private set; }
        public string? Description { get; set; }
        public Guid ProjectId { get; private set; }

        #region Relations

        public virtual ProjectEntity? Project { get; private set; }

        #endregion

        #region Ctor

        public ProjectStageTaskEntity(string title, Guid projectId)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("Title cannot be null.");
            Title = title;

            if (projectId == Guid.Empty)
                throw new ArgumentNullException("Project id cannot be null.");
            ProjectId = projectId;
        }

        #endregion
    }
}