using ContractorDocuments.Application.Projects.ViewModels;

namespace ContractorDocuments.Application.Projects.Queries
{
    public class GetStageMaterialsQuery : IRequest<IList<StageMaterialViewModel>>
    {
        public required Guid StageId { get; set; }
    }

    internal class GetStageMaterialsQueryHandler : IRequestHandler<GetStageMaterialsQuery, IList<StageMaterialViewModel>>
    {
        #region Fields & Ctor

        private readonly ILogger<GetStageMaterialsQueryHandler> _logger;
        private readonly ProjectReportService _projectReportService;
        public GetStageMaterialsQueryHandler(ILogger<GetStageMaterialsQueryHandler> logger,
            ProjectReportService projectReportService)
        {
            _logger = logger;
            _projectReportService = projectReportService;
        }

        #endregion

        public Task<IList<StageMaterialViewModel>> Handle(GetStageMaterialsQuery request, CancellationToken cancellationToken)
        {
            return _projectReportService.GetStageMaterialsAsync(request.StageId, cancellationToken);
        }
    }
}