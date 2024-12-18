using ContractorDocuments.Application.Categories.Models;

namespace ContractorDocuments.Application.Categories.Queries
{
    public class GetAllCategoryParentQuery : IRequest<IList<CategoryViewModel>>
    {

    }

    internal class GetAllCategoryParentQueryHandler : IRequestHandler<GetAllCategoryParentQuery, IList<CategoryViewModel>>
    {
        private readonly ILogger<GetAllCategoryParentQueryHandler> _logger;
        private readonly CategoryReportService _categoryReportService;
        private readonly CategoryModelFactory _categoryModelFactory;
        public GetAllCategoryParentQueryHandler(ILogger<GetAllCategoryParentQueryHandler> logger,
            CategoryReportService categoryReportService,
            CategoryModelFactory categoryModelFactory)
        {
            _logger = logger;
            _categoryReportService = categoryReportService;
            _categoryModelFactory = categoryModelFactory;
        }

        public async Task<IList<CategoryViewModel>> Handle(GetAllCategoryParentQuery request, CancellationToken cancellationToken)
        {
            // Get all category parents.
            var categories = await _categoryReportService.GetAllParentAsync(cancellationToken);

            return _categoryModelFactory.PrepareToViewModel(categories);
        }
    }
}