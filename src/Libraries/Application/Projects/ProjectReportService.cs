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

        public async Task<ProjectEntity?> GetProjectByIdIncludeDetailsAsync(Guid Id,
            CancellationToken cancellationToken = default)
        {
            var query = _projectNoTracking
                .Where(p => p.Id == Id)
                .Include(p => p.Contract)
                .Include(p => p.ConstructStages)
                // .ThenInclude(cs => cs.Supplies).Take(3)
                // .ThenInclude(cs => cs.Equipment).Take(3)
                // .ThenInclude(cs => cs.Expenses).Take(3)
                .AsQueryable();

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        #endregion
    }
}
