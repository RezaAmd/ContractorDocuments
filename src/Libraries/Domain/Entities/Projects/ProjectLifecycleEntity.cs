namespace BuildingMaterialAccounting.Domain.Entities.Projects
{
    public class ProjectLifecycleEntity : BaseEntity
    {
        public required string Title { get; set; }
        public int DisplayOrder { get; set; }
    }
}