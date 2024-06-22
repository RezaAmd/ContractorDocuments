namespace BuildingMaterialAccounting.Domain.Entities.Materials
{
    public class MaterialEntity : BaseEntity
    {
        public string Name { get; set; }

        #region Relations

        public virtual MaterialMeasureEntity? MeasurementUnits { get; private set; }

        #endregion

        #region Ctor

        public MaterialEntity(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Material name cannot be null.");
            Name = name;
        }

        #endregion
    }
}