using ContractorDocuments.Domain.Entities.Directory;

namespace ContractorDocuments.Domain.Entities.Materials
{
    public class MaterialEntity : BaseEntity
    {
        public required string Name { get; set; }
        public Guid? ParentMaterialId { get; set; } // Foreign Key
        public Guid MeasureId { get; private set; }

        #region Relations

        public virtual MeasureEntity? Measure { get; private set; }
        public virtual ICollection<MaterialEntity>? MaterialTypes { get; private set; }

        #endregion
    }
}