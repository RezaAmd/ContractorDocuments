using BuildingMaterialAccounting.Application.Customers.Commands.Register;
using WebUI.Areas.Admin.Models.Customers;

namespace WebUI.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Ctor

        public UserController(IMediator mediator)
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

        #endregion

        #region Json

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterUserPasswordInputModel userModel,
            CancellationToken cancellationToken)
        {
            var createUserResult = await _mediator.Send(new RegisterUserPasswordCommand()
            {
                PhoneNumber = userModel.PhoneNumber,
                Password = userModel.Password
            }, cancellationToken);

            if (createUserResult.IsSuccess)
            {
                return Ok(createUserResult);
            }
            return BadRequest(createUserResult);
        }

        [HttpPost]
        public IActionResult Update()
        {
            return Ok();
        }

        #endregion
    }
}
