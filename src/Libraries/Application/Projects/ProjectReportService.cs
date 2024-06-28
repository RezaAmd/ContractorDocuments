using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.Projects
{
    public class ProjectReportService
    {
        #region Fields & Ctor

        private readonly ILogger<ProjectReportService> _logger;
        private readonly IQueryable<ProjectEntity> _projectNoTracking;

        public ProjectReportService(ILogger<ProjectReportService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _projectNoTracking = context.Projects.AsNoTracking();
        }
        #endregion

        #region Methods

        public async Task<IList<ProjectEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _projectNoTracking.OrderBy(p => p.StartOn).ToListAsync(cancellationToken);
        }

        #endregion
    }
}
