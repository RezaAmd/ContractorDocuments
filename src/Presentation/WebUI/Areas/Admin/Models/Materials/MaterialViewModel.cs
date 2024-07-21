namespace ContractorDocuments.WebUI.Areas.Admin.Models.Materials
{
    public record MaterialViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public record MaterialWithChildrenViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<MaterialWithChildrenViewModel>? Children { get; set; }
    }
}
