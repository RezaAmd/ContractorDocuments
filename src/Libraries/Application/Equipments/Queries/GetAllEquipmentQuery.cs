using ContractorDocuments.Application.Equipments.ViewModels;

namespace ContractorDocuments.Application.Equipments.Queries
{
    public class GetAllEquipmentQuery : IRequest<IList<EquipmentViewModel>>
    {
    }
    internal class GetAllEquipmentQueryHandler : IRequestHandler<GetAllEquipmentQuery, IList<EquipmentViewModel>>
    {
        #region Fields & Ctor

        private readonly EquipmentReportService _equipmentReportService;
        public GetAllEquipmentQueryHandler(EquipmentReportService equipmentReportService)
        {
            _equipmentReportService = equipmentReportService;
        }

        #endregion

        public async Task<IList<EquipmentViewModel>> Handle(GetAllEquipmentQuery request, CancellationToken cancellationToken)
        {
            return await _equipmentReportService.GetAllEquipmentAsync(cancellationToken);
        }
    }
}