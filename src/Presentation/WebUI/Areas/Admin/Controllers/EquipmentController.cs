using ContractorDocuments.Application.Equipments.Commands;
using ContractorDocuments.Application.Equipments.Queries;
using ContractorDocuments.WebUI.Areas.Admin.Models.Equipments;

namespace ContractorDocuments.WebUI.Areas.Admin.Controllers
{
    public class EquipmentController : AdminBaseController
    {
        #region Fields & Ctor

        private readonly IMediator _mediator;
        public EquipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> Overview(CancellationToken cancellationToken)
        {
            var equipments = await _mediator.Send(new GetAllEquipmentQuery(), cancellationToken);
            return View(equipments);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateEquipmentInputModel equipmentInputModel,
            CancellationToken cancellationToken)
        {
            var createResult = await _mediator.Send(new CreateEquipmentCommand
            {
                Name = equipmentInputModel.name
            }, cancellationToken);
            return RedirectToAction("Overview");
        }

        #endregion

        #region Json



        #endregion
    }
}