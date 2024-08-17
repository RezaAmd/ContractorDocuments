using ContractorDocuments.Domain.Entities.Equipment;

namespace ContractorDocuments.Application.Equipments.Commands
{
    public class CreateEquipmentCommand : IRequest<Result>
    {
        public required string Name { get; set; }
    }

    internal class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, Result>
    {
        #region Fields & Ctor

        private readonly ILogger<CreateEquipmentCommand> _logger;
        private readonly EquipmentService _equipmentService;
        public CreateEquipmentCommandHandler(ILogger<CreateEquipmentCommand> logger,
            EquipmentService equipmentService)
        {
            _logger = logger;
            _equipmentService = equipmentService;
        }

        #endregion

        public async Task<Result> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            // Create new instance of equipment.
            var newEquipment = new EquipmentEntity(request.Name);
            // Add to database from service.
            return await _equipmentService.CreateAsync(newEquipment);
        }
    }
}