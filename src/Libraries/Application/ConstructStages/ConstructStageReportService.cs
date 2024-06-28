using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.ConstructStages
{
    public class ConstructStageReportService
    {
        #region Fields & Ctor

        private readonly ILogger<ConstructStageReportService> _logger;
        private readonly IQueryable<ConstructStageEntity> _constructStageQuery;

        public ConstructStageReportService(ILogger<ConstructStageReportService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _constructStageQuery = context.ConstructStages.AsNoTracking();
        }

        #endregion

        #region Methods

        public async Task<IList<ConstructStageEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _constructStageQuery.ToListAsync(cancellationToken);
        }

        #endregion
    }
}
