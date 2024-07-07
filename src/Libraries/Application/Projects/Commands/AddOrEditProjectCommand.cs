using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.Projects.Commands
{
    public class AddOrEditProjectCommand : IRequest<Result<ProjectEntity>>
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public ProjectType TypeId { get; set; }
        public ProjectContractType ContractTypeId { get; set; }
        public ProjectProcessStatusType ProcessStatusTypeId { get; set; }
        public DateTime? StartOn { get; set; }
        public DateTime? EndOn { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public byte SharePercentage { get; set; }
    }

    public class AddOrEditProjectCommandHandler : IRequestHandler<AddOrEditProjectCommand, Result<ProjectEntity>>
    {
        #region DI & Ctor

        private readonly ILogger<AddOrEditProjectCommandHandler> _logger;
        private readonly ProjectService _projectService;

        public AddOrEditProjectCommandHandler(ProjectService projectService,
            ILogger<AddOrEditProjectCommandHandler> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        #endregion

        public async Task<Result<ProjectEntity>> Handle(AddOrEditProjectCommand request, CancellationToken cancellationToken)
        {
            // Map request to project model.
            ProjectEntity? newProject = request.Adapt<ProjectEntity>();

            // Create new project.
            if (request.Id == Guid.Empty)
            {
                // Prepare contract.
                newProject.Contract = new()
                {
                    ContractTypeId = request.ContractTypeId,
                    Amount = request.Amount,
                    SharePercentage = request.SharePercentage,
                    ProjectId = newProject.Id
                };
                return await _projectService.AddAsync(newProject);
            }

            // Update exist project.
            var existProject = await _projectService.FindByIdAsync(request.Id,
                cancellationToken);

            // Checks if the project does not exist?
            if (existProject is null)
                return Result.Fail("Project not found!");

            // Map project to exist project.
            newProject.Adapt(existProject);

            // Update project.
            return await _projectService.UpdateAsync(newProject);
        }
    }
}