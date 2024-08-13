using ContractorDocuments.Application.Common.Extensions;
using ContractorDocuments.Application.ConstructStages.Queries;
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
                ContractTypeId = projectModel.ContractTypeId,
            };

            // StartOn
            if (projectModel.StartOn != null)
                command.StartOn = DateTime.Parse(projectModel.StartOn, new CultureInfo("fa-IR"));
            // EndOn
            if (projectModel.EndOn != null)
                command.EndOn = DateTime.Parse(projectModel.EndOn, new CultureInfo("fa-IR"));
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

            // Map to view model.
            var projectBoardViewModel = await _mediator.Send(new GetProjectBoardDetailsQuery
            {
                Id = Guid.Parse(id),
            }, cancellationToken);

            return View(projectBoardViewModel);
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

        #region Json

        #region Stage Material

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddStageMaterial([FromBody] CreateStageMaterialInputModel stageMaterialModel,
            CancellationToken cancellationToken)
        {
            if (stageMaterialModel == null)
                return BadRequest();
            var addStageMaterialCommand = new AddStageMaterialCommand
            {
                StageId = stageMaterialModel.StageId,
                MaterialId = stageMaterialModel.MaterialId,
                Amount = stageMaterialModel.Amount,
                UnitPrice = stageMaterialModel.UnitPrice
            };

            if (stageMaterialModel.TransportCost.HasValue)
                addStageMaterialCommand.TransportCost = stageMaterialModel.TransportCost.Value;
            if (stageMaterialModel.TotalNetProfit.HasValue)
                addStageMaterialCommand.TotalNetProfit = stageMaterialModel.TotalNetProfit.Value;
            if (!string.IsNullOrEmpty(stageMaterialModel.PurchasedOn))
                addStageMaterialCommand.PurchasedOn = DateTime.Parse(stageMaterialModel.PurchasedOn, new CultureInfo("fa-IR"));
            var addSupplyResult = await _mediator.Send(addStageMaterialCommand, cancellationToken);
            if (addSupplyResult.IsSuccess == false)
                return BadRequest(addSupplyResult);
            return Ok(addSupplyResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetStageMaterials(string stageId,
            CancellationToken cancellationToken)
        {
            var stageMaterials = await _mediator.Send(new GetStageMaterialsQuery
            {
                StageId = Guid.Parse(stageId)
            }, cancellationToken);
            return Ok(stageMaterials);
        }

        [HttpGet]
        public async Task<IActionResult> GetRemaningStages(string projectId,
            CancellationToken cancellationToken = default)
        {
            var remaningStages = await _mediator.Send(new GetRemaningStagesQuery
            {
                ProjectId = Guid.Parse(projectId)
            }, cancellationToken);

            return Ok(remaningStages);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMaterial(string id,
            CancellationToken cancellationToken = default)
        {
            Guid stageMaterialId = Guid.Parse(id);
            var deleteStageMaterialCommand = new DeleteStageMaterialCommand
            {
                StageMaterialId = stageMaterialId
            };

            var deleteStageMaterialResult = await _mediator.Send(deleteStageMaterialCommand, cancellationToken);

            if (deleteStageMaterialResult.IsSuccess == false)
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> TransferStageMaterial()
        {
            return Ok();
        }

        #endregion

        #region Stage Expenses

        [HttpGet]
        public async Task<IActionResult> GetStageExpenses(string stageId,
            CancellationToken cancellationToken)
        {
            var stageExpenses = await _mediator.Send(new GetStageExpensesQuery
            {
                StageId = Guid.Parse(stageId)
            }, cancellationToken);

            return Ok(stageExpenses);
        }

        [HttpPost]
        public async Task<IActionResult> AddStageExpenses([FromBody] AddExpensesInputModel expensesModel,
            CancellationToken cancellationToken)
        {
            var addExpenseCommand = new AddStageExpenseCommand
            {
                Title = expensesModel.Title,
                Amount = expensesModel.Amount,
                PaidOn = DateTime.Parse(expensesModel.PaidOn, new CultureInfo("fa-IR")),
                ProjectStageId = Guid.Parse(expensesModel.ProjectStageId),
                Description = expensesModel.Description
            };

            var addExpenseResult = await _mediator.Send(addExpenseCommand, cancellationToken);
            if (addExpenseResult.IsSuccess == false)
                return BadRequest(addExpenseResult);
            return Ok(addExpenseResult);
        }

        #endregion

        #endregion
    }
}
