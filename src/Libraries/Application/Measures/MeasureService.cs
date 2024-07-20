using ContractorDocuments.Domain.Entities.Directory;

namespace ContractorDocuments.Application.Measures
{
    internal class MeasureService
    {
        #region Fields & Ctor

        private readonly ILogger<MeasureService> _logger;
        private readonly IApplicationDbContext _context;
        public MeasureService(ILogger<MeasureService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<Result> CreateAsync(MeasureEntity measure,
            CancellationToken cancellationToken = default)
        {
            await _context.Measures.AddAsync(measure, cancellationToken);
            return await _context.SaveChangeAsync(cancellationToken);
        }

        #endregion
    }
}