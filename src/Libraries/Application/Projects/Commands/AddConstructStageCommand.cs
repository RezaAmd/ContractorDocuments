namespace ContractorDocuments.Application.Projects.Commands
{
    public class AddConstructStageCommand : IRequest<Result>
    {
        public required string ProjectId { get; set; }
        public required string ConstructStageId { get; set; }
    }

    internal class AddConstructStageCommandHandler : IRequestHandler<AddConstructStageCommand, Result>
    {
        #region Ctor

        private readonly ILogger<AddConstructStageCommandHandler> _logger;
        private readonly ProjectService _projectService;
        public AddConstructStageCommandHandler(ProjectService projectService,
            ILogger<AddConstructStageCommandHandler> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        #endregion

        public async Task<Result> Handle(AddConstructStageCommand request, CancellationToken cancellationToken)
        {
            return await _projectService.AddStageAsync(Guid.Parse(request.ProjectId),
                Guid.Parse(request.ConstructStageId),
                cancellationToken);
        }
    }
}