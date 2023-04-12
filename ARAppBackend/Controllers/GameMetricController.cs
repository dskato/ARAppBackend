﻿using ARAppBackend.Controllers.bases;
using ARAppBackend.DTOs.GameMetric;
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
        [Route("get-getgamemetricbyid")]
        public IActionResult GetGameMetricById([FromForm] int id)
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
    }
}
