using ContractorDocuments.Domain.Entities.Directory;

namespace ContractorDocuments.Application.Measures
{
    internal class MeasureReportService
    {
        #region Fields & Ctor

        private readonly ILogger<MeasureReportService> _logger;
        private readonly IQueryable<MeasureEntity> _queryAsNoTrack;
        public MeasureReportService(ILogger<MeasureReportService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _queryAsNoTrack = context.Measures.AsNoTracking();
        }

        #endregion

        #region Methods

        public async Task<IList<MeasureEntity>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _queryAsNoTrack.ToListAsync(cancellationToken);

        #endregion
    }
}