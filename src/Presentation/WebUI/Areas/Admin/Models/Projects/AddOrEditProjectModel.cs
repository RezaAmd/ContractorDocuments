namespace ContractorDocuments.WebUI.Areas.Admin.Models.Projects
{
    public partial class AddOrEditProjectModel
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public ProjectType TypeId { get; set; }
        public string? StartOn { get; set; }
        public string? EndOn { get; set; }
    }

    public partial class AddOrEditProjectModel
    {
        public ProjectContractType ContractTypeId { get; set; }
        public decimal? Amount { get; set; }
        public byte? SharePercentage { get; set; }
    }
}