using ContractorDocuments.Domain.Enums;

namespace WebUI.Areas.Admin.Models.Projects
{
    public partial class AddOrEditProjectModel
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public ProjectType TypeId { get; set; }
        public string? StartIn { get; set; }
        public string? EndIn { get; set; }
    }

    public partial class AddOrEditProjectModel
    {
        public ProjectContractType ContractTypeId { get; set; }
        public decimal Percentage { get; set; }
        public decimal Amount { get; set; }
    }
}