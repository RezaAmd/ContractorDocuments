namespace BuildingMaterialAccounting.Core.Domain.Catalogs
{
    public class ProjectMaterialEntity : BaseEntity
    {
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public decimal? NetProfit { get; set; }

        #region Relations

        public virtual MaterialMeasurementUnitEntity? MaterialMeasurementUnit { get; private set; }

        #endregion

        #region Ctor

        public ProjectMaterialEntity(decimal amount, decimal cost)
        {
            Amount = amount;
            Cost = cost;
        }

        #endregion
    }
}