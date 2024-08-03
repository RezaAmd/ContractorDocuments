
namespace ContractorDocuments.Application.Materials.Commands
{
    public class DeleteMaterialCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }

    internal class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand, Result>
    {
        #region Fields & Ctor

        private readonly MaterialService _materialService;
        public DeleteMaterialCommandHandler(MaterialService materialService)
        {
            _materialService = materialService;
        }

        #endregion

        public async Task<Result> Handle(DeleteMaterialCommand request,
            CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                return Result.Fail();

            var material = await _materialService.FindByIdAsync(request.Id);
            if (material == null)
                return Result.Fail();

            return await _materialService.DeleteAsync(material, cancellationToken);
        }
    }
}