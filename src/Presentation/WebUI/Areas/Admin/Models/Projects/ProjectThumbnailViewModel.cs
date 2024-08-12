namespace ContractorDocuments.WebUI.Areas.Admin.Models.Projects
{
    public record ProjectThumbnailViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public ProjectType ProjectTypeId { get; set; }
        public string ProjectType { get; set; } = string.Empty;
        public DateTime? StartOn { get; set; }
        public DateTime? EndOn { get; set; }
    }
}