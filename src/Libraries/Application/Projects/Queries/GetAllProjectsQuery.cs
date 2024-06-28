using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.Projects.Queries
{
    public class GetAllProjectsQuery : IRequest<IList<ProjectEntity>>
    {
    }

    internal class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IList<ProjectEntity>>
    {
        #region Fields & Ctor

        private readonly ILogger<GetAllProjectsQueryHandler> _logger;
        private readonly ProjectReportService _projectReportService;
        public GetAllProjectsQueryHandler(ILogger<GetAllProjectsQueryHandler> logger,
            ProjectReportService projectReportService)
        {
            _logger = logger;
            _projectReportService = projectReportService;
        }

        #endregion

        public async Task<IList<ProjectEntity>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _projectReportService.GetAllAsync(cancellationToken);
        }
    }
}
