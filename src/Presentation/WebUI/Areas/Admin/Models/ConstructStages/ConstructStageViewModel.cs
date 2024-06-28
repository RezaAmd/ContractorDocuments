namespace ContractorDocuments.WebUI.Areas.Admin.Models.ConstructStages
{
    public record ConstructStageViewModel
    {
        public string Name { get; set; }
        public ProjectType ProjectTypeId { get; set; }
        public string ProjectType { get; set; }
    }
}