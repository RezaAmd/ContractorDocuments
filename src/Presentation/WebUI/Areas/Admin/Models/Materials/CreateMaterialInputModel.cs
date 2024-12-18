namespace ContractorDocuments.WebUI.Areas.Admin.Models.Materials
{
    public record CreateMaterialInputModel
    {
        public string Name { get; set; } = string.Empty;
        public string? CategoryId { get; set; }
    }
}