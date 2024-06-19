namespace BuildingMaterialAccounting.Core.Domain.Catalogs
{
    public class MeasurementUnitEntity : BaseEntity
    {
        public string Title { get; set; }

        #region Ctor

        public MeasurementUnitEntity(string title)
        {
            Title = title;
        }

        #endregion
    }
}