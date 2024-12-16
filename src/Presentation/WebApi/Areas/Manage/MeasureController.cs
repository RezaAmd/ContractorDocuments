using ContractorDocuments.Application.Measures.Commands;
using ContractorDocuments.Application.Measures.Queries;

namespace ContractorDocuments.WebApi.Areas.Manage
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    public class MeasureController : ControllerBase
    {
        #region Ctor

        private readonly IMediator _mediator;
        public MeasureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Commands

        [HttpPost]
        public async Task<IActionResult> Create(CreateMeasureCommand createCommand,
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
            var measures = await _mediator.Send(new GetAllMeasureQuery(), cancellationToken);
            return Ok(measures);
        }

        #endregion
    }
}