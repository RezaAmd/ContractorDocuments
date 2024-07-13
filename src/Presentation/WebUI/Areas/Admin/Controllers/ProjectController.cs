using ContractorDocuments.Application.Common.Extensions;
using ContractorDocuments.Application.ConstructStages.Queries;
using ContractorDocuments.Application.Projects.Commands;
using ContractorDocuments.Application.Projects.Queries;
using ContractorDocuments.WebUI.Areas.Admin.Models.Projects;
using Mapster;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult> Board([FromRoute] string id,
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
            if (project == null)
                return RedirectToAction("Overview");
            // TODO:
            // Change Manual map to Auto map.
            ProjectBoardViewModel projectBoardVM = new();
            projectBoardVM = project.Adapt(projectBoardVM);
            projectBoardVM.ConstructionStages = project.Stages!.Select(cs => new ProjectConstructStageViewModel
            {
                Id = cs.Id.ToString(),
                Name = cs.ConstructStage!.Name,
                DisplayOrder = cs.ConstructStage!.DisplayOrder,
            }).OrderBy(cs => cs.DisplayOrder).ToList();
            // Prepare construct stages can be added.
            var constructStages = await _mediator.Send(new GetAllConstructStagesQuery
            {
                ProjectTypeId = project.ProjectTypeId
            }, cancellationToken);
            // Prepare list item.
            projectBoardVM.ConstructionStagesCanBeAdded = new List<SelectListItem>();
            projectBoardVM.ConstructionStagesCanBeAdded = constructStages.Select(cs => new SelectListItem
            {
                Value = cs.Id.ToString(),
                Text = cs.Name
            }).ToList();

            return View(projectBoardVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddConstructStage([FromForm] AddConstructStageInputModel constructStageModel,
            CancellationToken cancellationToken)
        {
            var addProjectStageResult = await _mediator.Send(new AddConstructStageCommand
            {
                ProjectId = constructStageModel.projectId,
                ConstructStageId = constructStageModel.constructStageId
            }, cancellationToken);

            return RedirectToAction("Board", new { Id = constructStageModel.projectId });
        }
        #endregion
    }
}
