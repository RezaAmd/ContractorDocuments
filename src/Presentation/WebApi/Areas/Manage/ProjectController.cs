using ContractorDocuments.Application.Projects.Commands;
using ContractorDocuments.Application.Projects.Queries;

namespace ContractorDocuments.WebApi.Areas.Manage
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    public class ProjectController : ControllerBase
    {
        #region DI & Ctor

        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Commands

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddOrEditProjectCommand addCommand,
            CancellationToken cancellationToken)
        {
            var createProjectResult = await _mediator.Send(addCommand, cancellationToken);
            if (createProjectResult.IsSuccess == false)
                return BadRequest(createProjectResult);

            return Ok(createProjectResult);
        }

        #endregion

        #region Queries

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var projects = await _mediator.Send(new GetAllProjectsQuery(), cancellationToken);

            return Ok(projects);
        }

        #endregion
    }
}