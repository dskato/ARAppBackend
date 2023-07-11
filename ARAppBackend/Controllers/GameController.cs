using ARAppBackend.Controllers.bases;
using ARAppBackend.DTOs.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ARAppBackend.Controllers
{
    public class GameController : APIControllerBase
    {
        private readonly IApplicationService _applicationService;

        public GameController(IApplicationService applicationService) : base(applicationService)
        {
            this._applicationService = applicationService;
        }

        [Authorize]
        [HttpPost]
        [Route("post-creategame")]
        public IActionResult CreateGame([FromForm] CreateGameRequest request)
        {
            try
            {
                var response = this._applicationService.CreateGame(request);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("delete-deletegame")]
        public IActionResult DeleteGame([FromForm] int id)
        {
            try
            {
                var response = this._applicationService.DeleteGameById(id);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("get-getgamebyid/{id}")]
        public IActionResult GetGameById(int id)
        {
            try
            {
                var response = this._applicationService.GetGameById(id);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("get-getallgames")]
        public IActionResult GetAllGames()
        {
            try
            {
                var response = this._applicationService.GetAllGames();
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("put-editgameinfo")]
        public IActionResult EditGameInfo(UpdateGameRequest request)
        {
            try
            {
                var response = this._applicationService.EditGameInfo(request);
                return Success(response);
            }
            catch (Exception exc)
            {
                return this.BadRequest(exc.Message);
            }
        }
    }
}
