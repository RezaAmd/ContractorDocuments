namespace BuildingMaterialAccounting.Core.Domain.Catalogs
{
    public class ServiceEntity : BaseEntity
    {
        public string Title { get; set; }

        public ServiceEntity(string title)
        {
            Title = title;
        }
    }
}