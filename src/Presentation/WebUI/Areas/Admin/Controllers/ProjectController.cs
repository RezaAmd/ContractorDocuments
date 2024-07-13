using ContractorDocuments.Application.Common.Extensions;
using ContractorDocuments.Application.Projects.Commands;
using ContractorDocuments.Application.Projects.Queries;
using ContractorDocuments.WebUI.Areas.Admin.Models.Projects;

namespace ContractorDocuments.WebUI.Areas.Admin.Controllers
{
    public class ProjectController : AdminBaseController
    {
        #region DI & Ctor

        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Pages

        [HttpGet]
        public async Task<IActionResult> Overview(CancellationToken cancellationToken)
        {
            var allProjects = await _mediator.Send(new GetAllProjectsQuery(),
                cancellationToken);

            return View(allProjects.Select(p => new ProjectThumbnailViewModel
            {
                Id = p.Id.ToString(),
                Title = p.Title,
                ProjectTypeId = p.ProjectTypeId,
                ProjectType = p.ProjectTypeId.ToDisplay(),
                StartOn = p.StartOn,
                EndOn = p.EndOn
            }).AsEnumerable());
        }

        [HttpGet]
        public IActionResult AddOrEdit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([FromForm] AddOrEditProjectModel projectModel,
            CancellationToken cancellationToken)
        {
            // Prepare project entity model.
            var command = new AddOrEditProjectCommand
            {
                Title = projectModel.Title,
                Description = projectModel.Description,
                TypeId = projectModel.TypeId,
                ContractTypeId = projectModel.ContractTypeId
            };

            // StartOn
            if (projectModel.StartOn != null)
                command.StartOn = DateTime.Parse(projectModel.StartOn);
            // EndOn
            if (projectModel.EndOn != null)
                command.EndOn = DateTime.Parse(projectModel.EndOn);
            // Amount
            if (projectModel.Amount != null)
                command.Amount = projectModel.Amount.Value;
            // SharePercentage
            if (projectModel.SharePercentage != null)
                command.SharePercentage = projectModel.SharePercentage.Value;

            var addOrEditResult = await _mediator.Send(command, cancellationToken);

            if (addOrEditResult.IsSuccess)
                return RedirectToAction("Board");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Board([FromQuery] string id,
            CancellationToken cancellationToken)
        {
            // TODO:
            // Validate by fluent validation.
            if (id == null)
                return RedirectToAction("Overview");
            // TODO:
            // Map to view model.
            var project = await _mediator.Send(new GetProjectBoardDetailsQuery
            {
                Id = Guid.Parse(id),
            }, cancellationToken);

            return View(project);
        }

        #endregion
    }
}
