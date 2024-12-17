using ContractorDocuments.Domain.Entities.Catalogs;
using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Domain.Entities.Equipment
{
    public class EquipmentEntity : BaseEntity
    {
        public string Name { get; set; }
        public Guid? CategoryId { get; set; }

        #region Relations

        public virtual ICollection<ProjectStageEquipmentEntity>? ProjectStageEquipments { get; set; }
        public virtual CategoryEntity? Category { get; set; }

        #endregion

        #region Ctor

        public EquipmentEntity(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Name cannot be null.");
            Name = name;
        }

        #endregion
    }
}