using ContractorDocuments.Application.Materials.Commands;
using ContractorDocuments.Application.Materials.Queries;
using MediatR;

namespace ContractorDocuments.WebApi.Areas.Manage
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    public class MaterialController : ControllerBase
    {
        #region DI & Ctor

        private readonly IMediator _mediator;
        public MaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Commands

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMaterialCommand createCommand,
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
            var materials = await _mediator.Send(new GetAllMaterialsTreeQuery(), cancellationToken);
            return Ok(materials);
        }

        [HttpGet]
        public async Task<IActionResult> GetParents(CancellationToken cancellationToken)
        {
            var materialParents = await _mediator.Send(new GetAllParentMaterialQuery(), cancellationToken);
            return Ok(materialParents);
        }

        #endregion
    }
}