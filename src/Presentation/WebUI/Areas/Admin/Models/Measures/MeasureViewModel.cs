namespace ContractorDocuments.WebUI.Areas.Admin.Models.Measures
{
    public record MeasureViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SystemKeyword { get; set; }
        public int DisplayOrder { get; set; }
    }
}
