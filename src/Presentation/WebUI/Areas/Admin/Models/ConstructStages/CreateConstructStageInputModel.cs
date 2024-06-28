namespace ContractorDocuments.WebUI.Areas.Admin.Models.ConstructStages
{
    public record CreateConstructStageInputModel(string Name, ProjectType ProjectTypeId, byte DisplayOrder);
}