namespace ContractorDocuments.WebUI.Areas.Admin.Models.ConstructStages
{
    public record ConstructStageViewModel
    {
        public string Name { get; set; } = string.Empty;
        public ProjectType ProjectTypeId { get; set; }
        public string ProjectType { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}