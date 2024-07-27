using ContractorDocuments.Application.Common.Extensions;
using ContractorDocuments.Application.ConstructStages;
using ContractorDocuments.Application.ConstructStages.ViewModels;

namespace ContractorDocuments.Application.Projects.Queries
{
    public class GetRemaningStagesQuery : IRequest<Result<List<ConstructStageViewModel>>>
    {
        public required Guid ProjectId { get; set; }
    }

    internal class GetRemaningStagesQueryHandler : IRequestHandler<GetRemaningStagesQuery, Result<List<ConstructStageViewModel>>>
    {
        #region Fields & Ctor

        private readonly ILogger<GetRemaningStagesQueryHandler> _logger;
        private readonly ConstructStageReportService _constructStageReportService;
        private readonly ProjectReportService _projectReportService;

        public GetRemaningStagesQueryHandler(ILogger<GetRemaningStagesQueryHandler> logger,
            ConstructStageReportService constructStageReportService,
            ProjectReportService projectReportService)
        {
            _logger = logger;
            _constructStageReportService = constructStageReportService;
            _projectReportService = projectReportService;
        }

        #endregion

        public async Task<Result<List<ConstructStageViewModel>>> Handle(GetRemaningStagesQuery request,
            CancellationToken cancellationToken)
        {
            // Find project with stages.
            var project = await _projectReportService.FindByIdIncludeStagesAsync(request.ProjectId,
                cancellationToken);
            if (project == null)
            {
                _logger.LogError("Project was not found by id: " + request.ProjectId);
                return Result.Fail("پروژه مورد نظر پیدا نشد!");
            }

            // find all stages. (with type of project)
            var constructionStages = await _constructStageReportService.GetAllAsync(project.ProjectTypeId,
                cancellationToken);
            if (constructionStages == null)
            {
                string projectType = project.ProjectTypeId.ToDisplay();
                _logger.LogError("There are not construction stages!");
                return Result.Fail($"هیچ مرحله ای برای '{projectType}' ایجاد نشده است.");
            }
            // Remove common stages with project.
            if (project.Stages != null && project.Stages.Count > 0)
            {
                // Remove common stages with project.
                constructionStages = constructionStages
                    .Where(cs => project.Stages.Select(s => s.ConstructStageId).ToArray().Contains(cs.Id) == false)
                    .ToList();
            }
            // Map to viewmodel.
            var constructStageViewModel = constructionStages.Select(cs => new ConstructStageViewModel
            {
                Id = cs.Id.ToString(),
                Name = cs.Name,
                DisplayOrder = cs.DisplayOrder
            }).ToList();

            return Result.Ok(constructStageViewModel);
        }
    }
}
