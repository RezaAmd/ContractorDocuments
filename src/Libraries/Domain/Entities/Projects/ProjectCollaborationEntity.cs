namespace ContractorDocuments.Domain.Entities.Projects
{
    public class ProjectCollaborationEntity
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public string Role { get; set; }
    }
}