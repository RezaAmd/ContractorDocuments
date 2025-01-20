using ContractorDocuments.Domain.Entities.Resources;
using System.Linq;

namespace ContractorDocuments.Application.Materials
{
    internal class MaterialService
    {
        #region Fields & Ctor

        private readonly ILogger<MaterialService> _logger;
        private readonly IApplicationDbContext _context;
        public MaterialService(ILogger<MaterialService> logger,
            IApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<Result> CreateAsync(MaterialEntity material,
            CancellationToken cancellationToken = default)
        {
            await _context.Materials.AddAsync(material, cancellationToken);
            return await _context.SaveChangeAsync(cancellationToken);
        }

        public async Task<MaterialEntity?> FindByIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _context.Materials
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Result> DeleteAsync(MaterialEntity material,
            CancellationToken cancellationToken = default)
        {
            _context.Materials.Remove(material);
            return await _context.SaveChangeAsync(cancellationToken);
        }

        #endregion
    }
}