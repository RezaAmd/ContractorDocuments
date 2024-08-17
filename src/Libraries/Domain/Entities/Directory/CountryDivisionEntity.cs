namespace ContractorDocuments.Domain.Entities.Directory
{
    public class CountryDivisionEntity : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public CountryDivisionType DivisionTypeId { get; set; }
        public Guid? ParentId { get; set; }

        #region Relations

        public virtual CountryDivisionEntity? Parent { get; set; }
        public virtual ICollection<CountryDivisionEntity>? Children { get; set; }

        #endregion

        #region Ctors

        public CountryDivisionEntity(string name, CountryDivisionType divisionTypeId, Guid? parentId)
        {
            SetName(name);
            ParentId = parentId;
            if (parentId.HasValue == false && parentId != Guid.Empty)
                divisionTypeId = CountryDivisionType.Country;
            else
                DivisionTypeId = divisionTypeId;
        }

        #endregion

        #region Methods

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name cannot be null.");
            Name = name;
        }

        #endregion
    }
}