namespace ContractorDocuments.WebUI.Areas.Admin.Models.Measures
{
    public record MeasureViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string SystemKeyword { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}