using ContractorDocuments.Domain.Entities.Catalogs;

namespace ContractorDocuments.Application.Categories
{
    public class CategoryReportService
    {
        #region DI & Ctor

        private readonly ILogger<CategoryReportService> _logger;
        private readonly IQueryable<CategoryEntity> _queryAsNoTracking;
        public CategoryReportService(ILogger<CategoryReportService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _queryAsNoTracking = context.Categories.AsNoTracking();
        }

        #endregion

        #region Methods

        public async Task<IList<CategoryEntity>> GetAllAsync(CategoryRelevantEntityType? relevantEntityTypeId = null,
            CancellationToken cancellationToken = default)
        {
            var query = _queryAsNoTracking.AsQueryable();

            if (relevantEntityTypeId != null)
            {
                query = query.Where(c => c.RelevantEntityTypeId == relevantEntityTypeId);
                if (relevantEntityTypeId == CategoryRelevantEntityType.Material)
                    query = query.Include(c => c.Materials);
                if (relevantEntityTypeId == CategoryRelevantEntityType.Equipment)
                    query = query.Include(c => c.Equipments);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IList<CategoryEntity>> GetAllParentAsync(CancellationToken cancellationToken = default)
            => await _queryAsNoTracking.Where(c => c.ParentId == null).ToListAsync(cancellationToken);

        public async Task<bool> IsExistAsync(CategoryEntity category, CancellationToken cancellationToken = default)
            => await _queryAsNoTracking.AnyAsync(c => c.Name == category.Name && c.RelevantEntityTypeId == category.RelevantEntityTypeId, cancellationToken);

        #endregion
    }
}