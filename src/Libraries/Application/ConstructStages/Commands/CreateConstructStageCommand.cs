using ContractorDocuments.Domain.Entities.Projects;

namespace ContractorDocuments.Application.ConstructStages.Commands
{
    public class CreateConstructStageCommand : IRequest<Result>
    {
        public required string Name { get; set; }
        public required ProjectType ProjectTypeId { get; set; }
        public byte DisplayOrder { get; set; } = 0;
    }

    internal class CreateConstructStageCommandHandler : IRequestHandler<CreateConstructStageCommand, Result>
    {
        #region Fields & Ctor

        private readonly ILogger<CreateConstructStageCommandHandler> _logger;
        private readonly ConstructStageService _constructStageService;

        public CreateConstructStageCommandHandler(ILogger<CreateConstructStageCommandHandler> logger,
            ConstructStageService constructStageService)
        {
            _logger = logger;
            _constructStageService = constructStageService;
        }

        #endregion

        public async Task<Result> Handle(CreateConstructStageCommand request, CancellationToken cancellationToken)
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