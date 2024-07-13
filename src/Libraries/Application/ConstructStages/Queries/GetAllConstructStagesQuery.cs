using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.ConstructStages.Queries
{
    public class GetAllConstructStagesQuery : IRequest<IList<ConstructStageEntity>>
    {
        public ProjectType? ProjectTypeId { get; set; } = null;
    }

    internal class GetAllConstructStagesQueryHandler : IRequestHandler<GetAllConstructStagesQuery, IList<ConstructStageEntity>>
    {
        #region Field & Ctor

        private readonly ILogger<GetAllConstructStagesQueryHandler> _logger;
        private readonly ConstructStageReportService _constructStageReportService;

        public GetAllConstructStagesQueryHandler(ILogger<GetAllConstructStagesQueryHandler> logger,
            ConstructStageReportService constructStageReportService)
        {
            _logger = logger;
            _constructStageReportService = constructStageReportService;
        }

        #endregion

        public async Task<IList<ConstructStageEntity>> Handle(GetAllConstructStagesQuery request, CancellationToken cancellationToken)
        {
            return await _constructStageReportService.GetAllAsync(request.ProjectTypeId, cancellationToken);
        }
    }
}