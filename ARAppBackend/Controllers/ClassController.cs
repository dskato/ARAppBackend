using ARAppBackend.Controllers.bases;
using ARAppBackend.DTOs.Class;
using Microsoft.AspNetCore.Mvc;

namespace ARAppBackend.Controllers
{
    public class ClassControler : APIControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ClassControler(IApplicationService applicationService) : base(applicationService)
        {
            this._applicationService = applicationService;
        }

        [HttpPost]
        [Route("post-adduserinclass")]
        public IActionResult AddUserInClass([FromForm] int userId, [FromForm] string classCode)
        {
            try
            {
                this._applicationService.AddUserInClass(userId, classCode);
                return Success("Usuario agregado en clase!");
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }


        [HttpPost]
        [Route("post-createclass")]
        public IActionResult CreateClass([FromForm] CreateClassRequest request)
        {
            try
            {
                var response = this._applicationService.CreateClass(request);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpDelete]
        [Route("delete-deleteclass")]
        public IActionResult DeleteClass([FromForm] int id)
        {
            try
            {
                var response = this._applicationService.DeleteClassById(id);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-getclassbyid/{id}")]
        public IActionResult GetClassById(int id)
        {
            try
            {
                var response = this._applicationService.GetClassById(id);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-getallclasess")]
        public IActionResult GetAllClasses()
        {
            try
            {
                var response = this._applicationService.GetAllClasses();
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpPut]
        [Route("put-editclassinfo")]
        public IActionResult EditClassInfo(UpdateClassRequest request)
        {
            try
            {
                var response = this._applicationService.EditClassInfo(request);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-getusersinclass/{classId}")]
        public IActionResult GetUsersInClassByClassId(int classId)
        {
            try
            {
                var response = this._applicationService.GetUsersInClassByClassId(classId);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-getclassesofuser/{userId}")]
        public IActionResult GetClassesOfUserByUserId(int userId)
        {
            try
            {
                var response = this._applicationService.GetClassesOfUserByUserId(userId);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

         [HttpGet]
        [Route("get-GetAllClassesByTextSearch/{textSearch}")]
        public IActionResult GetAllClassesByTextSearch(string textSearch)
        {
            try
            {
                var response = this._applicationService.GetAllClassesByTextSearch(textSearch);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-getallmcu")]
        public IActionResult GetAllMCU()
        {
            try
            {
                var response = this._applicationService.GetAllMCU();
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

    }
}
