using ARAppBackend.Controllers.bases;
using ARAppBackend.DTOs.GameMetric;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ARAppBackend.Controllers
{
    public class GameMetricController : APIControllerBase
    {
        private readonly IApplicationService _applicationService;

        public GameMetricController(IApplicationService applicationService) : base(applicationService)
        {
            this._applicationService = applicationService;
        }

        [HttpPost]
        [Route("post-creategamemetric")]
        public IActionResult CreateGameMetric([FromForm] CreateGameMetricRequest request)
        {
            try
            {
                var response = this._applicationService.CreateGameMetric(request);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpDelete]
        [Route("delete-deletegamemetric")]
        public IActionResult DeleteGameMetric([FromForm] int id)
        {
            try
            {
                var response = this._applicationService.DeleteGameMetricById(id);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-getgamemetricbyid/{id}")]
        public IActionResult GetGameMetricById(int id)
        {
            try
            {
                var response = this._applicationService.GetGameMetricById(id);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-getallgamesmetrics")]
        public IActionResult GetAllGamesMetrics()
        {
            try
            {
                var response = this._applicationService.GetAllGameMetrics();
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpPut]
        [Route("put-editgamemetricinfo")]
        public IActionResult EditGameInfo(UpdateGameMetricRequest request)
        {
            try
            {
                var response = this._applicationService.EditGameMetricInfo(request);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-rsfbyclassid/{classId}/{difficulty}")]
        public IActionResult RatioSuccessFailReportByClassId(int classId, string difficulty)
        {
            try
            {
                var response = this._applicationService.RatioSuccessFailReportByClassId(classId, difficulty);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-rsfbyuserid/{userId}/{difficulty}")]
        public IActionResult RatioSuccessFailReportByUserId(int userId, string difficulty)
        {
            try
            {
                var response = this._applicationService.RatioSuccessFailReportByUserId(userId, difficulty);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-GetMostFailsOrSuccessByClassOrUser/{userOrClass}/{failOrSuccess}/{gameId}/{difficulty}/{userOrClassId}")]
        public IActionResult GetMostFailsOrSuccessByClassOrUser(int userOrClass, int failOrSuccess, int gameId, string difficulty, int userOrClassId)
        {
            try
            {
                var response = this._applicationService.GetMostFailsOrSuccessByClassOrUser(userOrClass, failOrSuccess, gameId, difficulty, userOrClassId);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-ElapsedTimeByClassOrUser/{userOrClass}/{difficulty}/{userOrClassId}")]
        public IActionResult ElapsedTimeByClassOrUser(int userOrClass, string difficulty, int userOrClassId)
        {
            try
            {
                var response = this._applicationService.ElapsedTimeByClassOrUser(userOrClass, difficulty, userOrClassId);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("get-GeneralRanking/{userOrClass}/{gameId}/{difficulty}/{userOrClassId}")]
        public IActionResult GeneralRanking(int userOrClass, int gameId, string difficulty, int userOrClassId)
        {
            try
            {
                var response = this._applicationService.GeneralRanking(userOrClass, gameId, difficulty, userOrClassId);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }
    }
}
