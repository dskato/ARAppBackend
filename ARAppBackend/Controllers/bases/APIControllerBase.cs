using ARAppBackend.DTOs;
using ARAppBackend.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ARAppBackend.Controllers.bases
{
    [ApiController]
    public abstract class APIControllerBase : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        protected APIControllerBase(IApplicationService applicationService)
        {
            this._applicationService = applicationService;
        }
        protected ActionResult Success(object data = null, ResponseCodeText codeText = ResponseCodeText.SUCCESS)
        {
            return Ok(new ResponseBase()
            {
                Code = ResponseCode.OK,
                Data = data,
                CodeText = codeText.ToString()
            });
        }
        protected ActionResult Ok(string message, object data)
        {
            return Ok(new ResponseBase()
            {
                Code = ResponseCode.OK,
                Message = "Sucess",
                Data = data
            });
        }

        protected ActionResult NoData()
        {
            return Ok(new ResponseBase()
            {
                Code = ResponseCode.NO_DATA,
                Message = "No data found."
            });
        }

        protected new ActionResult NotFound()
        {
            return NotFound(new ResponseBase()
            {
                Code = ResponseCode.NOT_FOUND,
                Message = "Record not found"
            });
        }

        protected ActionResult BadRequest(string message)
        {
            return BadRequest(new ResponseBase()
            {
                Code = ResponseCode.BAD_REQUEST,
                Message = message
            });
        }
    }
}
