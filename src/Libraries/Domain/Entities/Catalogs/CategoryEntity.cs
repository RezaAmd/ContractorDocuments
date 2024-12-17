using ContractorDocuments.Domain.Entities.Equipment;
using ContractorDocuments.Domain.Entities.Materials;

namespace ContractorDocuments.Domain.Entities.Catalogs
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public CategoryRelevantEntityType RelevantEntityTypeId { get; set; }
        public Guid? ParentId { get; set; }

        public virtual CategoryEntity? Parent { get; set; }
        public virtual ICollection<CategoryEntity>? SubCategories { get; set; }
        public virtual ICollection<MaterialEntity>? Materials { get; set; }
        public virtual ICollection<EquipmentEntity>? Equipments { get; set; }

        public CategoryEntity(string name)
        {
            Name = name;
        }
    }
}