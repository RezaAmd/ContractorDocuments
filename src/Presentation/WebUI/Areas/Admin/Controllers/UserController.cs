using ContractorDocuments.Application.Users.Commands;
using ContractorDocuments.Application.Users.Queries;
using ContractorDocuments.Domain.ValueObjects;
using ContractorDocuments.WebUI.Areas.Admin.Models.Users;
using System.Globalization;

namespace ContractorDocuments.WebUI.Areas.Admin.Controllers
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

        #region Methods

        [HttpGet]
        public async Task<IActionResult> Overview(CancellationToken cancellationToken)
        {
            var allUsers = await _mediator.Send(new GetAllUsersQuery()
                , cancellationToken);
            return View(allUsers.Select(u => new UserViewModel
            {
                Name = u.Fullname.Name,
                Surname = u.Fullname.Surname,
                PhoneNumber = u.PhoneNumber,
                CreatedOn = u.CreatedOn.ToString("dd MMMM yyyy - HH:mm", new CultureInfo("fa-Ir"))
            }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] CreateUserInputModel userModel)
        {
            var createUserCommand = new CreateUserCommand
            {
                PhoneNumber = userModel.PhoneNumber,
                Password = userModel.Password
            };

            if (!string.IsNullOrEmpty(userModel.Name) || !string.IsNullOrEmpty(userModel.Surname))
                createUserCommand.Fullname = new Fullname(userModel.Name, userModel.Surname);

            var createUserCommandResult = _mediator.Send(createUserCommand);

            return RedirectToAction("Overview");
        }

        #endregion

        #region Json

        //[HttpGet]
        //public IActionResult GetList()
        //{
        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] RegisterUserPasswordInputModel userModel,
        //    CancellationToken cancellationToken)
        //{
        //    var createUserResult = await _mediator.Send(new RegisterUserPasswordCommand()
        //    {
        //        PhoneNumber = userModel.PhoneNumber,
        //        Password = userModel.Password
        //    }, cancellationToken);

        //    if (createUserResult.IsSuccess)
        //    {
        //        return Ok(createUserResult);
        //    }
        //    return BadRequest(createUserResult);
        //}

        //[HttpPost]
        //public IActionResult Update()
        //{
        //    return Ok();
        //}

        #endregion
    }
}
