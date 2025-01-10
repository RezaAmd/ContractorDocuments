namespace ContractorDocuments.Domain.Entities.Projects
{
    public class ProjectAddressEntity : BaseEntity
    {
        public Guid CityId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
    }
}