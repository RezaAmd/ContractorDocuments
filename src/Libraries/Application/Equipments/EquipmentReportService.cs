using ContractorDocuments.Application.Equipments.ViewModels;
using ContractorDocuments.Domain.Entities.Equipment;

namespace ContractorDocuments.Application.Equipments
{
    public class EquipmentReportService
    {
        #region Fields & Ctor

        private readonly ILogger<EquipmentReportService> _logger;
        private readonly IQueryable<EquipmentEntity> _EquipmentNoTracking;
        public EquipmentReportService(ILogger<EquipmentReportService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _EquipmentNoTracking = context.Equipments.AsNoTracking();
        }

        #endregion

        #region Methods

        public async Task<IList<EquipmentViewModel>> GetAllEquipmentAsync(CancellationToken cancellationToken = default)
        {
            return await _EquipmentNoTracking
                .Select(equipment => new EquipmentViewModel
                {
                    Name = equipment.Name
                })
                .ToListAsync();
        }

        #endregion
    }
}