
using ContractorDocuments.Domain.Entities.Materials;

namespace ContractorDocuments.Application.Materials.Commands
{
    public class CreateMaterialCommand : IRequest<Result>
    {
        public required string Name { get; set; }
        public required string MeasureId { get; set; }
        public string? ParentMaterialId { get; set; }
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
                Name = request.Name,
                MeasureId = Guid.Parse(request.MeasureId)
            };
            // Map parent id if exist.
            if(!string.IsNullOrEmpty(request.ParentMaterialId))
                newMaterial.ParentMaterialId = Guid.Parse(request.ParentMaterialId);
            // Add new material to db.
            return await _materialService.CreateAsync(newMaterial, cancellationToken);
        }
    }
}