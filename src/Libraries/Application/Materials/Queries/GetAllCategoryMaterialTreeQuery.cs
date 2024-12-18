using ContractorDocuments.Application.Categories;
using ContractorDocuments.Application.Categories.Models;
using ContractorDocuments.Domain.Entities.Catalogs;

namespace ContractorDocuments.Application.Materials.Queries
{
    public class GetAllCategoryMaterialTreeQuery : IRequest<IList<CategoryViewModel>>
    {
    }

    internal class GetAllCategoryMaterialTreeQueryHandler : IRequestHandler<GetAllCategoryMaterialTreeQuery, IList<CategoryViewModel>>
    {
        #region DI & Ctor
        private readonly ILogger<GetAllCategoryMaterialTreeQueryHandler> _logger;
        private readonly CategoryReportService _categoryReportService;
        private readonly CategoryModelFactory _categoryModelFactory;
        public GetAllCategoryMaterialTreeQueryHandler(ILogger<GetAllCategoryMaterialTreeQueryHandler> logger,
            CategoryReportService categoryReportService,
            CategoryModelFactory categoryModelFactory)
        {
            _logger = logger;
            _categoryReportService = categoryReportService;
            _categoryModelFactory = categoryModelFactory;
        }
        #endregion

        public async Task<IList<CategoryViewModel>> Handle(GetAllCategoryMaterialTreeQuery request, CancellationToken cancellationToken)
        {
            // Get all categories including material.
            var categories = await _categoryReportService.GetAllAsync(CategoryRelevantEntityType.Material, cancellationToken);
            return _categoryModelFactory.PrepareToTreeViewModel(categories);
        }
    }
}