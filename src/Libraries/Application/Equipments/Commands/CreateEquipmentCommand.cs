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
        private readonly EquipmentReportService _equipmentReportService;
        public CreateEquipmentCommandHandler(ILogger<CreateEquipmentCommand> logger,
            EquipmentService equipmentService,
            EquipmentReportService equipmentReportService)
        {
            _logger = logger;
            _equipmentService = equipmentService;
            _equipmentReportService = equipmentReportService;
        }

        #endregion

        public async Task<Result> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            // Create new instance of equipment.
            var newEquipment = new EquipmentEntity(request.Name);

            // Check is equipment exist?
            bool isEquipmentExist = await _equipmentReportService.IsExistByNameAsync(request.Name);
            if (isEquipmentExist)
                return Result.Fail($"مورد '{request.Name}' از قبل ایجاد شد.");

            // Add to database from service.
            return await _equipmentService.CreateAsync(newEquipment);
        }
    }
}