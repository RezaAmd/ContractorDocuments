namespace ContractorDocuments.WebUI.Areas.Admin.Models.Projects
{
    public record ProjectThumbnailViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public ProjectType ProjectTypeId { get; set; }
        public string ProjectType { get; set; }
        public DateTime? StartOn { get; set; }
        public DateTime? EndOn { get; set; }
    }
}
