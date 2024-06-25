using BuildingMaterialAccounting.Domain.Entities.Materials;

namespace BuildingMaterialAccounting.Domain.Entities.Projects
{
    public class ProjectMaterialEntity : BaseEntity
    {
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public decimal? NetProfit { get; set; }

        #region Relations

        public virtual MaterialMeasureEntity? MaterialMeasurementUnit { get; private set; }

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