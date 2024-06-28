using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.Projects
{
    public class ProjectService
    {
        #region Fields & Ctor

        private readonly IApplicationDbContext _context;
        public ProjectService(IApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<ProjectEntity?> FindByIdAsync(Guid id,
            CancellationToken cancellationToken = default)
            => await _context.Projects.FindAsync(id, cancellationToken);

        public async Task<Result<ProjectEntity>> AddAsync(ProjectEntity project,
            CancellationToken cancellationToken = default)
        {
            await _context.Projects.AddAsync(project, cancellationToken);
            return await _context.SaveChangeAsync(cancellationToken);
        }

        public async Task<Result<ProjectEntity>> UpdateAsync(ProjectEntity project,
            CancellationToken cancellationToken = default)
        {
            _context.Projects.Update(project);
            return await _context.SaveChangeAsync(cancellationToken);
        }


        #endregion
    }
}