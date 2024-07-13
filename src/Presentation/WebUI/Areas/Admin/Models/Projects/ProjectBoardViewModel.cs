using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContractorDocuments.WebUI.Areas.Admin.Models.Projects
{
    public class ProjectBoardViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal TotalCost { get; set; }
        public List<ProjectConstructStageViewModel> ConstructionStages { get; set; }
        public List<SelectListItem> ConstructionStagesCanBeAdded { get; set; }
    }

    public class ProjectConstructStageViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
        public int DisplayOrder { get; set; }
    }
}