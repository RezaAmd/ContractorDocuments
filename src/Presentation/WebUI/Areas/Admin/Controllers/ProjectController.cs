using BuildingMaterialAccounting.Application.Projects.Commands;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models.Projects;

namespace WebUI.Areas.Admin.Controllers
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
        public IActionResult Overview()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddOrEdit()
        {
            return View();
        }

        [HttpPost]
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

            return View();
        }

        #endregion
    }
}
