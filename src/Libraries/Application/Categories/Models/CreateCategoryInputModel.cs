using ContractorDocuments.Domain.Entities.Catalogs;

namespace ContractorDocuments.Application.Categories.Models
{
    public class CreateCategoryInputModel
    {
        public string Name { get; set; }
        public CategoryRelevantEntityType RelevantEntityTypeId { get; set; }
        public string? ParentId { get; set; }
    }
}