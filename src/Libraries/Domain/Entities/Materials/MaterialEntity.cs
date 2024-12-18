using ContractorDocuments.Domain.Entities.Catalogs;
using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Domain.Entities.Materials
{
    public class MaterialEntity : BaseEntity
    {
        public required string Name { get; set; }
        public Guid? CategoryId { get; set; }

        #region Relations

        public virtual CategoryEntity? Category { get; set; }
        public virtual ICollection<ProjectStageMaterialEntity>? ProjectStageMaterials { get; private set; }

        #endregion
    }
}