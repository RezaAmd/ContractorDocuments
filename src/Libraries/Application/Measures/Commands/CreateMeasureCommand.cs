using ContractorDocuments.Domain.Entities.Directory;

namespace ContractorDocuments.Application.Measures.Commands
{
    public class CreateMeasureCommand : IRequest<Result>
    {
        public required string Name { get; set; }
        public required string SystemKeyword { get; set; }
        public int DisplayOrder { get; set; } = 0;
    }
    internal class CreateMeasureCommandHandler : IRequestHandler<CreateMeasureCommand, Result>
    {
        #region Fields & Ctor

        private readonly ILogger<CreateMeasureCommandHandler> _logger;
        private readonly MeasureService _measureService;
        public CreateMeasureCommandHandler(ILogger<CreateMeasureCommandHandler> logger,
            MeasureService measureService)
        {
            _logger = logger;
            _measureService = measureService;
        }

        #endregion

        public async Task<Result> Handle(CreateMeasureCommand request, CancellationToken cancellationToken)
        {
            // Create new instance of measure.
            MeasureEntity newMeasure = new(request.Name, request.SystemKeyword);
            newMeasure.DisplayOrder = request.DisplayOrder;
            // Add to db.
            return await _measureService.CreateAsync(newMeasure, cancellationToken);
        }
    }
}