namespace ContractorDocuments.Application.ConstructStages.ViewModels
{
    public record ConstructStageViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}