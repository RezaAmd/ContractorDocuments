namespace ContractorDocuments.WebUI.Areas.Admin.Models.Materials
{
    public record MaterialViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public record MaterialWithChildrenViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public IList<MaterialWithChildrenViewModel>? Children { get; set; }
    }
}
