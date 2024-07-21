using ContractorDocuments.Domain.Entities.Materials;

namespace ContractorDocuments.Application.Materials
{
    internal class MaterialReportService
    {
        #region Field & Ctor

        private readonly ILogger<MaterialReportService> _logger;
        private readonly IQueryable<MaterialEntity> _queryAsNoTracking;

        public MaterialReportService(ILogger<MaterialReportService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _queryAsNoTracking = context.Materials.AsNoTracking();
        }

        #endregion

        #region Methods

        public async Task<IList<MaterialEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _queryAsNoTracking.ToListAsync(default);
        }

        public async Task<IList<MaterialEntity>> GetAllParentAsync(CancellationToken cancellationToken = default)
        {
            return await _queryAsNoTracking
                .Where(m => m.ParentMaterialId == null)
                .ToListAsync(cancellationToken);
        }

        public async Task<MaterialEntity?> GetMaterialByIdIncludeChildrenAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _queryAsNoTracking
                .Where(m => m.Id == id)
                .Include(m => m.ChildrenMaterial)
                .FirstOrDefaultAsync(cancellationToken);
        }
        #endregion
    }
}