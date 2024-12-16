using ContractorDocuments.Application.Materials.Queries;
using MediatR;

namespace ContractorDocuments.WebApi.Areas.Manage
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MaterialController : ControllerBase
    {
        #region DI & Ctor

        private readonly IMediator _mediator;
        public MaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var materials = _mediator.Send(new GetAllMaterialsTreeQuery(), cancellationToken);

            return Ok(materials);
        }

        [HttpGet]
        public async Task<IActionResult> GetParents(CancellationToken cancellationToken)
        {
            var materialParents = _mediator.Send(new GetAllParentMaterialQuery(), cancellationToken);
            return Ok(materialParents);
        }
    }
}