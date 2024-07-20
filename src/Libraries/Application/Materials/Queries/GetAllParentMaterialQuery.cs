using ContractorDocuments.Domain.Entities.Materials;

namespace ContractorDocuments.Application.Materials.Queries
{
    public class GetAllParentMaterialQuery : IRequest<IList<MaterialEntity>>
    {
    }

    internal class GetAllParentMaterialQueryHandler : IRequestHandler<GetAllParentMaterialQuery, IList<MaterialEntity>>
    {
        #region Fields & Ctor

        private readonly MaterialReportService _reportService;
        public GetAllParentMaterialQueryHandler(MaterialReportService reportService)
        {
            _reportService = reportService;
        }

        #endregion

        public async Task<IList<MaterialEntity>> Handle(GetAllParentMaterialQuery request,
            CancellationToken cancellationToken)
        {
            return await _reportService.GetAllParentAsync(cancellationToken);
        }
    }
}