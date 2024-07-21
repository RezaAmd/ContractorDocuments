using ContractorDocuments.Domain.Entities.Materials;

namespace ContractorDocuments.Domain.Entities.Directory
{
    public class MeasureEntity : BaseEntity
    {
        public string Name { get; set; }
        public string SystemKeyword { get; set; }
        public int DisplayOrder { get; set; }

        #region Ctor

        public MeasureEntity(string name, string systemKeyword)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Name cannot be null.");
            Name = name;

            if (string.IsNullOrEmpty(systemKeyword)) throw new ArgumentNullException("SystemKeyword cannot be null.");
            SystemKeyword = systemKeyword;
        }

        #endregion

        #region Relations

        public virtual ICollection<MaterialEntity> Materials { get; set; }

        #endregion
    }
}