using ContractorDocuments.Application.Categories.Models;
using ContractorDocuments.Domain.Entities.Catalogs;

namespace ContractorDocuments.Application.Categories
{
    public class CategoryModelFactory
    {
        #region DI & Ctor

        private readonly ILogger<CategoryModelFactory> _logger;
        private readonly CategoryReportService _reportService;
        public CategoryModelFactory(ILogger<CategoryModelFactory> logger,
            CategoryReportService reportService)
        {
            _logger = logger;
            _reportService = reportService;
        }

        #endregion

        #region Methods

        public CategoryEntity? PrepareToEntityModel(CreateCategoryInputModel inputModel)
        {
            return inputModel.Adapt<CategoryEntity>();
        }

        public IList<CategoryViewModel> PrepareToViewModel(IList<CategoryEntity> categories)
        {
            return categories.Adapt<IList<CategoryViewModel>>();
        }

        public IList<CategoryViewModel> PrepareToTreeViewModel(IList<CategoryEntity> categories)
        {
            // Step 1: Create a dictionary for quick lookup by ID
            var categoryDictionary = categories.ToDictionary(c => c.Id, c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                RelevantEntityTypeId = c.RelevantEntityTypeId,
                SubCategories = new List<CategoryViewModel>(),
                Items = new List<CategoryItemViewModel>()
            });

            // Step 2: Populate the tree structure
            var rootCategories = new List<CategoryViewModel>();
            foreach (var category in categories)
            {
                var viewModel = categoryDictionary[category.Id];

                // Add materials and equipment to items
                if (category.Materials != null)
                {
                    viewModel.Items!.AddRange(category.Materials.Select(m => new CategoryItemViewModel
                    {
                        Id = m.Id.ToString(),
                        Name = m.Name
                    }));
                }

                if (category.Equipments != null)
                {
                    viewModel.Items!.AddRange(category.Equipments.Select(e => new CategoryItemViewModel
                    {
                        Id = e.Id.ToString(),
                        Name = e.Name
                    }));
                }

                // Add to parent's SubCategories if it has a parent
                if (category.ParentId.HasValue && categoryDictionary.TryGetValue(category.ParentId.Value, out var parentViewModel))
                {
                    parentViewModel.SubCategories!.Add(viewModel);
                }
                else
                {
                    // If no parent, add to root categories
                    rootCategories.Add(viewModel);
                }
            }

            // Return the root categories
            return rootCategories;
        }

        #endregion
    }
}