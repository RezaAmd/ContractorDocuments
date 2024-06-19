namespace BuildingMaterialAccounting.Core.Domain.Catalogs
{
    public class ProjectServiceEntity : BaseEntity
    {
        public Guid ServiceId { get; private set; }
        public decimal Cost { get; set; }
        public decimal? NetProfit { get; set; }
        public string? Description { get; set; }

        #region Relations

        public virtual ServiceEntity? Service { get; set; }

        #endregion

        #region Ctor

        public ProjectServiceEntity(Guid serviceId, decimal cost)
        {
            ServiceId = serviceId;
            Cost = cost;
        }

        #endregion
    }
}