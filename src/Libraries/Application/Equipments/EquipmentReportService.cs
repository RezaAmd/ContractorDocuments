using ContractorDocuments.Application.Equipments.ViewModels;
using ContractorDocuments.Domain.Entities.Resources;

namespace ContractorDocuments.Application.Equipments
{
    public class EquipmentReportService
    {
        #region Fields & Ctor

        private readonly ILogger<EquipmentReportService> _logger;
        private readonly IQueryable<EquipmentEntity> _equipmentNoTracking;
        public EquipmentReportService(ILogger<EquipmentReportService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _equipmentNoTracking = context.Equipments.AsNoTracking();
        }

        #endregion

        #region Methods

        public async Task<IList<EquipmentViewModel>> GetAllEquipmentAsync(CancellationToken cancellationToken = default)
        {
            return await _equipmentNoTracking
                .ProjectToType<EquipmentViewModel>()
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> IsExistByNameAsync(string name)
            => await _equipmentNoTracking.AnyAsync(e => e.Name == name);

        #endregion
    }
}