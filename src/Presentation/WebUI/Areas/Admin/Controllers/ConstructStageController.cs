using ContractorDocuments.Application.Common.Extensions;
using ContractorDocuments.Application.ConstructStages.Commands;
using ContractorDocuments.Application.ConstructStages.Queries;
using ContractorDocuments.WebUI.Areas.Admin.Models.ConstructStages;

namespace ContractorDocuments.WebUI.Areas.Admin.Controllers
{
    public class ConstructStageController : AdminBaseController
    {
        #region Fields & Ctor

        private IMediator _mediator;

        public ConstructStageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Pages

        [HttpGet]
        public async Task<IActionResult> Overview(CancellationToken cancellationToken)
        {
            var getAllStages = await _mediator.Send(new GetAllConstructStagesQuery(),
                cancellationToken);

            // Map to view model
            IList<ConstructStageViewModel> stagesViewModel = new List<ConstructStageViewModel>();
            if (getAllStages != null)
            {
                stagesViewModel = getAllStages.Select(cs => new ConstructStageViewModel
                {
                    Name = cs.Name,
                    ProjectTypeId = cs.ProjectTypeId,
                    ProjectType = cs.ProjectTypeId.ToDisplay(),
                    DisplayOrder = cs.DisplayOrder
                }).ToList();
            }

            return View(stagesViewModel);
        }

        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateConstructStageInputModel constructStageModel,
            CancellationToken cancellationToken)
        {
            var createResult = await _mediator.Send(new CreateConstructStageCommand
            {
                Name = constructStageModel.Name,
                ProjectTypeId = constructStageModel.ProjectTypeId,
                DisplayOrder = constructStageModel.DisplayOrder
            }, cancellationToken);

            return RedirectToAction("Overview");
        }

        #region Json

        #endregion
    }
}