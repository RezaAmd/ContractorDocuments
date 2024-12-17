using ContractorDocuments.Domain.Entities.Catalogs;
using ContractorDocuments.Domain.Entities.Directory;
using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Domain.Entities.Materials
{
    public class MaterialEntity : BaseEntity
    {
        public required string Name { get; set; }
        public Guid? ParentMaterialId { get; set; } // Foreign Key
        public Guid MeasureId { get; set; }
        public Guid? CategoryId { get; set; }

        #region Relations

        public virtual MeasureEntity? Measure { get; private set; }
        public virtual ICollection<MaterialEntity>? ChildrenMaterial { get; private set; }
        public virtual MaterialEntity? ParentMaterial { get; set; }
        public virtual ICollection<ProjectStageMaterialEntity>? ProjectStageMaterials { get; private set; }
        public virtual CategoryEntity? Category { get; set; }

        #endregion
    }
}