using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.ConstructStages
{
    public class ConstructStageService
    {
        #region Fields & Ctor

        private readonly ILogger<ConstructStageService> _logger;
        private readonly IApplicationDbContext _context;

        public ConstructStageService(ILogger<ConstructStageService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<Result> CreateAsync(ConstructStageEntity constructStage,
            CancellationToken cancellationToken = default)
        {
            if (constructStage == null) return Result.Fail("Construction stage cannot be null!");
            // Add entity.
            await _context.ConstructStages.AddAsync(constructStage, cancellationToken);
            // save changes.
            return await _context.SaveChangeAsync(cancellationToken);
        }

        #endregion
    }
}