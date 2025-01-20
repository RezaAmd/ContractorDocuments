using ContractorDocuments.Domain.Entities.Resources;

namespace ContractorDocuments.Domain.Entities.Catalogs
{
    public class CategoryEntity : BaseEntity
    {
        public required string Name { get; set; }
        public CategoryRelevantEntityType RelevantEntityTypeId { get; set; }
        public Guid? ParentId { get; set; }

        public virtual CategoryEntity? Parent { get; set; }
        public virtual ICollection<CategoryEntity>? SubCategories { get; set; }
        public virtual ICollection<MaterialEntity>? Materials { get; set; }
        public virtual ICollection<EquipmentEntity>? Equipments { get; set; }
    }
}