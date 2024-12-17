using ContractorDocuments.Application.ConstructStages.Commands;
using ContractorDocuments.Application.ConstructStages.Queries;
using ContractorDocuments.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace ContractorDocuments.WebApi.Areas.Manage
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    [Authorize]
    public class ConstructStageController : ControllerBase
    {
        #region DI & Ctor

        private readonly IMediator _mediator;
        public ConstructStageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Commands

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateConstructStageCommand createCommand,
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
        public async Task<IActionResult> GetAll(ProjectType? projectTypeId,
            CancellationToken cancellationToken)
        {
            var getAllStagesQuery = new GetAllConstructStagesQuery();
            if (projectTypeId != null)
                getAllStagesQuery.ProjectTypeId = projectTypeId;

            var constructStages = await _mediator.Send(getAllStagesQuery, cancellationToken);

            return Ok(constructStages);
        }

        #endregion
    }
}