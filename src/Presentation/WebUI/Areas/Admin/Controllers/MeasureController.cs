﻿using ContractorDocuments.Application.Measures.Commands;
using ContractorDocuments.Application.Measures.Queries;
using ContractorDocuments.WebUI.Areas.Admin.Models.Measures;

namespace ContractorDocuments.WebUI.Areas.Admin.Controllers
{
    public class MeasureController : AdminBaseController
    {
        #region Fields & Ctor

        private readonly IMediator _mediator;
        public MeasureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> Overview(CancellationToken cancellationToken)
        {
            var measures = await _mediator.Send(new GetAllMeasureQuery(),
                cancellationToken);

            IList<MeasureViewModel> measuresViewModel = measures.Adapt<IList<MeasureViewModel>>();

            return View(measuresViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateMeasureInputModel MeasureModel,
            CancellationToken cancellationToken)
        {
            var createResult = await _mediator.Send(new CreateMeasureCommand
            {
                Name = MeasureModel.Name,
                SystemKeyword = MeasureModel.SystemKeyword,
                DisplayOrder = MeasureModel.DisplayOrder
            }, cancellationToken);

            return RedirectToAction("Overview");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var measures = await _mediator.Send(new GetAllMeasureQuery(),
                cancellationToken);
            if (measures == null)
                return NoContent();
            var measuresVM = measures.Select(m => new MeasureViewModel
            {
                Id = m.Id.ToString(),
                Name = m.Name,
                SystemKeyword = m.SystemKeyword,
                DisplayOrder = m.DisplayOrder
            }).ToList();

            return Ok(measuresVM);
        }
    }
}