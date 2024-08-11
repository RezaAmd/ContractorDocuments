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

        #region Construct Stages

        public async Task<Result> AddStageAsync(Guid projectId, Guid constructStageId,
            CancellationToken cancellationToken = default)
        {
            if (await _context.ProjectStages
                .Where(ps => ps.ProjectId == projectId && ps.ConstructStageId == constructStageId)
                .AnyAsync(cancellationToken))
                return Result.Fail();

            ProjectStageEntity newProjectStage = new()
            {
                ProjectId = projectId,
                ConstructStageId = constructStageId
            };
            await _context.ProjectStages.AddAsync(newProjectStage, cancellationToken);
            return await _context.SaveChangeAsync(cancellationToken);
        }

        public async Task<Result> AddStageMaterialAsync(ProjectStageMaterialEntity stageMaterial,
            CancellationToken cancellationToken = default)
        {
            await _context.ProjectStageMaterials.AddAsync(stageMaterial, cancellationToken);
            return await _context.SaveChangeAsync(cancellationToken);
        }

        public async Task<ProjectStageMaterialEntity?> FindStageMaterialByIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _context.ProjectStageMaterials
                .Where(psm => psm.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Result> DeleteStageMaterialAsync(ProjectStageMaterialEntity projectStageMaterial,
            CancellationToken cancellationToken = default)
        {
            _context.ProjectStageMaterials.Remove(projectStageMaterial);
            return await _context.SaveChangeAsync(cancellationToken);
        }
        #endregion

        #endregion
    }
}