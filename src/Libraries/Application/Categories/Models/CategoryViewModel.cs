using ContractorDocuments.Domain.Entities.Catalogs;
using System.Text.Json.Serialization;

namespace ContractorDocuments.Application.Categories.Models
{
    public partial record CategoryViewModel
    {
        public Guid Id { get; set; }
        public CategoryRelevantEntityType RelevantEntityTypeId { get; set; }
        public required string Name { get; set; }
    }

    public partial record CategoryViewModel
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CategoryViewModel>? SubCategories { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CategoryItemViewModel>? Items { get; set; }
    }

    public partial record CategoryItemViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? CategoryId { get; set; }
    }
}