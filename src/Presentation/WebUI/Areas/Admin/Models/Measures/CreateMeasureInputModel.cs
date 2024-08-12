namespace ContractorDocuments.WebUI.Areas.Admin.Models.Measures
{
    public record CreateMeasureInputModel
    {
        public string Name { get; set; } = string.Empty;
        public string SystemKeyword { get; set; } = string.Empty;
        public int DisplayOrder { get; set; } = 0;
    }
}