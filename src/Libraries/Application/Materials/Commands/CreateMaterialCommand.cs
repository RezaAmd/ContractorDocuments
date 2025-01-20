using ContractorDocuments.Domain.Entities.Resources;

namespace ContractorDocuments.Application.Materials.Commands
{
    public class CreateMaterialCommand : IRequest<Result>
    {
        public required string Name { get; set; }
        public string? CategoryId { get; set; }
    }

    internal class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, Result>
    {
        #region Fields & Ctor

        private readonly MaterialService _materialService;
        public CreateMaterialCommandHandler(MaterialService materialService)
        {
            _materialService = materialService;
        }

        #endregion

        public async Task<Result> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            // Create new instance of material.
            MaterialEntity newMaterial = new()
            {
                Name = request.Name
            };
            if (!string.IsNullOrEmpty(request.CategoryId))
            {
                newMaterial.CategoryId = Guid.Parse(request.CategoryId);
            }
            // Add new material to db.
            return await _materialService.CreateAsync(newMaterial, cancellationToken);
        }
    }
}