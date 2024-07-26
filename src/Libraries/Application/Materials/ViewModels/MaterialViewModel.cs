namespace ContractorDocuments.Application.Materials.ViewModels
{
    public class MaterialViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Measure { get; set; }
        public IList<MaterialViewModel>? Children { get; set; }
        public MaterialViewModel? ParentMaterial { get; set; }
    }
}