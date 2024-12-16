using ContractorDocuments.Application.Equipments.Commands;
using ContractorDocuments.Application.Equipments.Queries;

namespace ContractorDocuments.WebApi.Areas.Manage
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    public class EquipmentController : ControllerBase
    {
        #region DI & Ctor

        private readonly IMediator _mediator;
        public EquipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Commands

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEquipmentCommand createCommand,
            CancellationToken cancellationToken)
        {
            var createResult = await _mediator.Send(createCommand, cancellationToken);

            if (createResult.IsSuccess == false)
                return BadRequest(createResult);

            return Ok(createResult);
        }

        #endregion

        #region Queries

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var equipment = await _mediator.Send(new GetAllEquipmentQuery(), cancellationToken);

            return Ok(equipment);
        }

        #endregion
    }
}