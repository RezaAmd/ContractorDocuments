using ContractorDocuments.Application.Categories.Commands;
using ContractorDocuments.Application.Categories.Queries;

namespace ContractorDocuments.WebApi.Areas.Manage
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        #region DI & Ctor

        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Commands

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand createCommand,
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
        public async Task<IActionResult> GetAllTree(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllCategoryTreeQuery(), cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParents(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllCategoryParentQuery(), cancellationToken));
        }

        #endregion
    }
}