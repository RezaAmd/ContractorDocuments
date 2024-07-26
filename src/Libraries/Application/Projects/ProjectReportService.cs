using ContractorDocuments.Application.Projects.ViewModels;
using ContractorDocuments.Domain.Entities.Projects;
using System.Net.Http.Headers;

namespace ContractorDocuments.Application.Projects
{
    public class ProjectReportService
    {
        #region Fields & Ctor

        private readonly ILogger<ProjectReportService> _logger;
        private readonly IQueryable<ProjectEntity> _projectNoTracking;
        private readonly IQueryable<ProjectStageEntity> _projectStageNoTracking;

        public ProjectReportService(ILogger<ProjectReportService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _projectNoTracking = context.Projects.AsNoTracking();
            _projectStageNoTracking = context.ProjectStages.AsNoTracking();
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
                .Include(p => p.Stages!)
                    .ThenInclude(cs => cs.ConstructStage)
                .Include(p => p.Stages!)
                    .ThenInclude(ps => ps.Materials!)
                    .ThenInclude(psm => psm.Material)
                .Take(3)
                // .Include(p => p.Stages!)
                // .ThenInclude(cs => cs.Equipment).Take(3)
                // .Include(p => p.Stages!)
                // .ThenInclude(cs => cs.Expenses).Take(3)
                .AsQueryable();

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        #region Stages

        public async Task<IList<StageMaterialViewModel>> GetStageMaterialsAsync(Guid stageId,
            CancellationToken cancellationToken = default)
        {
            return await _projectStageNoTracking.Where(ps => ps.Id == stageId)
                .SelectMany(ps => ps.Materials!)
                .Include(psm => psm.Material)
                .Select(psm => new StageMaterialViewModel
                {
                    Id = psm.Id.ToString(),
                    Name = psm.Material!.Name,
                    Amount = psm.Amount,
                    UnitPrice = psm.UnitPrice,
                    TotalNetProfit = psm.TotalNetProfit
                }).ToListAsync(cancellationToken);
        }
        #endregion

        #endregion
    }
}
