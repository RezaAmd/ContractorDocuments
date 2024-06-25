using BuildingMaterialAccounting.Domain.Entities.Projects;

namespace BuildingMaterialAccounting.Application.Projects
{
    public class ProjectService
    {
        #region Fields

        private readonly IApplicationDbContext _context;

        #endregion

        #region Ctor

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
            if (Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken)))
                return Result.Ok(project);
            return Result.Fail();
        }

        public async Task<Result<ProjectEntity>> UpdateAsync(ProjectEntity project,
            CancellationToken cancellationToken = default)
        {
            _context.Projects.Update(project);
            
            if (Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken)))
                return Result.Ok(project);
            return Result.Fail();
        }


        #endregion
    }
}
