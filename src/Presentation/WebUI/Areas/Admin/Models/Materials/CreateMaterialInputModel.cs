namespace ContractorDocuments.WebUI.Areas.Admin.Models.Materials
{
    public record CreateMaterialInputModel
    {
        public string Name { get; set; } = string.Empty;
        public string ParentMaterialId { get; set; } = string.Empty;
        public string MeasureId { get; set; } = string.Empty;
    }
}