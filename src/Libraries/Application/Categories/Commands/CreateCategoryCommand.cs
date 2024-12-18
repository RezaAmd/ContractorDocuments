using ContractorDocuments.Application.Categories.Models;

namespace ContractorDocuments.Application.Categories.Commands
{
    public class CreateCategoryCommand : CreateCategoryInputModel, IRequest<Result>
    {

    }

    internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result>
    {
        #region DI & Ctor

        private readonly ILogger<CreateCategoryCommandHandler> _logger;
        private readonly CategoryService _categoryService;
        private readonly CategoryModelFactory _categoryModelFactory;
        public CreateCategoryCommandHandler(ILogger<CreateCategoryCommandHandler> logger,
            CategoryService categoryService,
            CategoryModelFactory categoryModelFactory)
        {
            _logger = logger;
            _categoryService = categoryService;
            _categoryModelFactory = categoryModelFactory;
        }

        #endregion

        public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Prepare to entity instance.
            var categoryEntity = _categoryModelFactory.PrepareToEntityModel(request);

            // Add to database.
            return await _categoryService.CreateAsync(categoryEntity, cancellationToken);
        }
    }
}