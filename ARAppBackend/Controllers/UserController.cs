using ARAppBackend.Controllers.bases;
using ARAppBackend.DTOs.RestorePassword;
using ARAppBackend.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ARAppBackend.Controllers
{
    [ApiController]
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

        [HttpPost]
        [Route("post-updateuser")]
        public IActionResult UpdateUser([FromForm] UpdateUserRequest request)
        {
            try
            {
                
                var response = this._applicationService.UpdateUserById(request);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpPost]
        [Route("post-changestatus")]
        public IActionResult ChangeStatus([FromForm] int userId,[FromForm] bool isUserActive )
        {
            try
            {
                var response = this._applicationService.ChangeStatus(userId, isUserActive);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("post-login")]
        public IActionResult LogIn([FromForm] string email, [FromForm] string password)
        {
            try
            {
                var response = this._applicationService.LogIn(email, password);
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
        [Route("get-getuserbyid/{id}")]
        public IActionResult GetUserById(int id)
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
        [Route("get-getuserbyemail/{email}")]
        public IActionResult GetUserByEmail( string email)
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

        [HttpPost]
        [Route("post-createcode")]
        public async Task<IActionResult> CreateCodeAsync([FromForm] CreatePasswordRestoreRequest request)
        {
            try
            {
                var response = await this._applicationService.CreateCodeAsync(request);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpPost]
        [Route("post-verifycode")]
        public IActionResult VerifyCode([FromForm] string email, [FromForm] string code)
        {
            try
            {
                var response = this._applicationService.VerifyCode(email, code);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpPost]
        [Route("post-restorepassword")]
        public IActionResult RestorePassword([FromForm] string email, [FromForm] string newPassword)
        {
            try
            {
                var response = this._applicationService.ChangePassword(email, newPassword);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-GetAllUsersByTextSearch/{textSearch}")]
        public IActionResult GetAllUsersByTextSearch(string textSearch)
        {
            try
            {
                var response = this._applicationService.GetAllUsersBySearchText(textSearch);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }
    }
}
