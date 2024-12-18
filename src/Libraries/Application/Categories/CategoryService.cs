using ContractorDocuments.Domain.Entities.Catalogs;

namespace ContractorDocuments.Application.Categories
{
    public class CategoryService
    {
        #region DI & Ctor

        private readonly ILogger<CategoryService> _logger;
        private readonly IApplicationDbContext _context;
        private readonly CategoryReportService _categoryReportService;
        public CategoryService(ILogger<CategoryService> logger,
            IApplicationDbContext context,
            CategoryReportService categoryReportService)
        {
            _logger = logger;
            _context = context;
            _categoryReportService = categoryReportService;
        }

        #endregion

        #region Methods

        public async Task<Result> CreateAsync(CategoryEntity category,
            CancellationToken cancellationToken = default)
        {
            // Check category is exist?
            if (await _categoryReportService.IsExistAsync(category,cancellationToken))
            {
                _logger.LogWarning("Cannot insert duplicate category.");
                return Result.Fail("این دسته بندی قبلا ایجاد شده.");
            }

            // Add new category to db.
            await _context.Categories.AddAsync(category, cancellationToken);
            return await _context.SaveChangeAsync(cancellationToken);
        }

        #endregion
    }
}