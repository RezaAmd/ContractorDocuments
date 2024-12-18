using ContractorDocuments.Application.Categories.Models;

namespace ContractorDocuments.Application.Categories.Queries
{
    public class GetAllCategoryTreeQuery : IRequest<IList<CategoryViewModel>>
    {
    }

    internal class GetAllCategoryTreeQueryHandler : IRequestHandler<GetAllCategoryTreeQuery, IList<CategoryViewModel>>
    {
        private readonly ILogger<GetAllCategoryTreeQueryHandler> _logger;
        private readonly CategoryReportService _categoryReportService;
        private readonly CategoryModelFactory _categoryModelFactory;
        public GetAllCategoryTreeQueryHandler(ILogger<GetAllCategoryTreeQueryHandler> logger,
            CategoryReportService categoryReportService,
            CategoryModelFactory categoryModelFactory)
        {
            _logger = logger;
            _categoryReportService = categoryReportService;
            _categoryModelFactory = categoryModelFactory;
        }

        public async Task<IList<CategoryViewModel>> Handle(GetAllCategoryTreeQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryReportService.GetAllAsync(relevantEntityTypeId: null, cancellationToken);

            return _categoryModelFactory.PrepareToTreeViewModel(categories);
        }
    }
}
