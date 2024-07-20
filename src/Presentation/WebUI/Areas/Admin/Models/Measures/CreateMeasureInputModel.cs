namespace ContractorDocuments.WebUI.Areas.Admin.Models.Measures
{
    public record CreateMeasureInputModel
    {
        public string Name { get; set; }
        public string SystemKeyword { get; set; }
        public int DisplayOrder { get; set; }
    }
}