namespace ContractorDocuments.Application.ConstructStages.ViewModels
{
    public record ConstructStageViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}