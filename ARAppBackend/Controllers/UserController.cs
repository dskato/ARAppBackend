using ARAppBackend.Controllers.bases;
using ARAppBackend.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace ARAppBackend.Controllers
{
    public class UserController : APIControllerBase
    {
        private readonly IApplicationService _applicationService;

        public UserController(IApplicationService applicationService) : base(applicationService)
        {
            this._applicationService = applicationService;
        }

        [HttpPost]
        [Route("post-createuser")]
        public IActionResult CreateUser([FromForm] CreateUserRequest request)
        {
            try
            {
                var response = this._applicationService.CreateUser(request);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpDelete]
        [Route("delete-deleteuser")]
        public IActionResult DeleteUser([FromForm] int id)
        {
            try
            {
                var response = this._applicationService.DeleteUserById(id);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-getuserbyid")]
        public IActionResult GetUserById([FromForm] int id)
        {
            try
            {
                var response = this._applicationService.GetUserById(id);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-getuserbyemail")]
        public IActionResult GetUserByEmail([FromForm] string email)
        {
            try
            {
                var response = this._applicationService.GetUserByEmail(email);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }


        [HttpGet]
        [Route("get-getallusers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var response = this._applicationService.GetAllUsers();
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpPut]
        [Route("put-forgotpassword")]
        public IActionResult ForgotPassword([FromForm] string email, string newPassword)
        {
            try
            {
                var response = this._applicationService.ForgotPassword(email, newPassword);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }
    }
}
