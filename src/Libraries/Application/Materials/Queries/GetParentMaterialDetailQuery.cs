using ContractorDocuments.Domain.Entities.Materials;

namespace ContractorDocuments.Application.Materials.Queries
{
    public class GetParentMaterialDetailQuery : IRequest<MaterialEntity?>
    {
        public Guid Id { get; set; }
    }

    internal class GetParentMaterialDetailQueryHandler : IRequestHandler<GetParentMaterialDetailQuery, MaterialEntity?>
    {
        #region Fields & Ctor

        private readonly ILogger<GetParentMaterialDetailQueryHandler> _logger;
        private readonly MaterialReportService _materialReportService;

        public GetParentMaterialDetailQueryHandler(ILogger<GetParentMaterialDetailQueryHandler> logger,
            MaterialReportService materialReportService)
        {
            _logger = logger;
            _materialReportService = materialReportService;
        }

        #endregion

        public async Task<MaterialEntity?> Handle(GetParentMaterialDetailQuery request, CancellationToken cancellationToken)
        {
            return await _materialReportService.GetMaterialByIdIncludeChildrenAsync(request.Id, cancellationToken);
        }
    }
}