namespace ContractorDocuments.WebUI.Areas.Admin.Models.Materials
{
    public record CreateMaterialInputModel
    {
        public string Name { get; set; }
        public string ParentMaterialId { get; set; }
        public string MeasureId { get; set; }
    }
}