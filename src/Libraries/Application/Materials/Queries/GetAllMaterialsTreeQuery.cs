using ContractorDocuments.Application.Materials.ViewModels;

namespace ContractorDocuments.Application.Materials.Queries
{
    public class GetAllMaterialsTreeQuery : IRequest<IList<MaterialViewModel>>
    {
    }
    internal class GetAllMaterialsTreeQueryHandler : IRequestHandler<GetAllMaterialsTreeQuery, IList<MaterialViewModel>>
    {
        #region Fields & Ctor

        private readonly MaterialReportService _materialReportService;

        public GetAllMaterialsTreeQueryHandler(MaterialReportService materialReportService)
        {
            _materialReportService = materialReportService;
        }

        #endregion

        public async Task<IList<MaterialViewModel>> Handle(GetAllMaterialsTreeQuery request, CancellationToken cancellationToken)
        {
            return await _materialReportService.GetAllParentIncludeChildAsync(cancellationToken);
        }
    }
}
