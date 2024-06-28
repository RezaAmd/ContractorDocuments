using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.ConstructStages.Commands
{
    public class AddConstructStageCommand : IRequest<Result>
    {
        public required string Name { get; set; }
        public required ProjectType ProjectTypeId { get; set; }
        public byte DisplayOrder { get; set; } = 0;
    }

    internal class AddConstructStageCommandHandler : IRequestHandler<AddConstructStageCommand, Result>
    {
        #region Fields & Ctor

        private readonly ILogger<AddConstructStageCommandHandler> _logger;
        private readonly ConstructStageService _constructStageService;

        public AddConstructStageCommandHandler(ILogger<AddConstructStageCommandHandler> logger,
            ConstructStageService constructStageService)
        {
            _logger = logger;
            _constructStageService = constructStageService;
        }

        #endregion

        public async Task<Result> Handle(AddConstructStageCommand request, CancellationToken cancellationToken)
        {
            // Prepare new instance
            ConstructStageEntity newConstructStage = new()
            {
                Name = request.Name,
                ProjectTypeId = request.ProjectTypeId,
                DisplayOrder = request.DisplayOrder
            };
            // Store async.
            var createStageResult = await _constructStageService.CreateAsync(newConstructStage, cancellationToken);
            // Log on failed to create.
            if (createStageResult.IsSuccess == false)
            {
                _logger.LogError($"Failed on create new construct stage with name '{request.Name}'.");
            }

            return createStageResult;
        }
    }
}