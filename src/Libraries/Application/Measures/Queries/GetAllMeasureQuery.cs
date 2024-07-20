using ContractorDocuments.Domain.Entities.Directory;

namespace ContractorDocuments.Application.Measures.Queries
{
    public class GetAllMeasureQuery : IRequest<IList<MeasureEntity>>
    {
    }
    internal class GetAllMeasureQueryHandler : IRequestHandler<GetAllMeasureQuery, IList<MeasureEntity>>
    {
        #region Fields & Ctor

        private readonly ILogger<GetAllMeasureQueryHandler> _logger;
        private readonly MeasureReportService _measureReportService;
        public GetAllMeasureQueryHandler(ILogger<GetAllMeasureQueryHandler> logger,
            MeasureReportService measureReportService)
        {
            _logger = logger;
            _measureReportService = measureReportService;
        }

        #endregion

        public async Task<IList<MeasureEntity>> Handle(GetAllMeasureQuery request,
            CancellationToken cancellationToken)
        {
            return await _measureReportService.GetAllAsync(cancellationToken);
        }
    }
}