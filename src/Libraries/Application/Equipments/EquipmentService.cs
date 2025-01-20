using ContractorDocuments.Domain.Entities.Resources;

namespace ContractorDocuments.Application.Equipments
{
    public class EquipmentService
    {
        #region Fields & Ctor

        private readonly ILogger<EquipmentService> _logger;
        private readonly IApplicationDbContext _context;
        public EquipmentService(ILogger<EquipmentService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<Result> CreateAsync(EquipmentEntity equipment,
            CancellationToken cancellationToken = default)
        {
            await _context.Equipments.AddAsync(equipment, cancellationToken);
            return await _context.SaveChangeAsync(cancellationToken);
        }

        #endregion
    }
}