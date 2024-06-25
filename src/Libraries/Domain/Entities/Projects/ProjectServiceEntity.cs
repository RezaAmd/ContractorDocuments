namespace BuildingMaterialAccounting.Domain.Entities.Projects
{
    public class ProjectServiceEntity : BaseEntity
    {
        public string Title { get; private set; }
        public decimal Cost { get; set; }
        public decimal? NetProfit { get; set; }
        public string? Description { get; set; }
        public Guid ProjectId { get; private set; }

        #region Relations

        public virtual ProjectEntity? Project { get; private set; }

        #endregion

        #region Ctor

        public ProjectServiceEntity(string title, decimal cost, Guid projectId)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("Title cannot be null.");
            Title = title;

            if (cost < 0)
                throw new ArgumentOutOfRangeException("Cost cannot be less than 0.");
            Cost = cost;

            if (projectId == Guid.Empty)
                throw new ArgumentNullException("Project id cannot be null.");
            ProjectId = projectId;
        }

        #endregion
    }
}