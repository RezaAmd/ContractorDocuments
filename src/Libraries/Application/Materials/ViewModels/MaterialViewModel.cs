namespace ContractorDocuments.Application.Materials.ViewModels
{
    public class MaterialViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Measure { get; set; } = string.Empty;
        public IList<MaterialViewModel>? Children { get; set; }
        public MaterialViewModel? ParentMaterial { get; set; }
    }
}