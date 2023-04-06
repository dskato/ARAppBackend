using ARAppBackend.DTOs.GameMetric;
using Domain.Entities;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {
        public GetGameMetricResponse CreateGame(CreateGameMetricRequest request) { 

            var response = new GetGameMetricResponse();
            GameMetricEntity entity = new GameMetricEntity();

            entity.GameId = request.GameId;
            entity.UserId = request.UserId;
            entity.ClassId = request.ClassId;
            entity.Score = request.Score;
            entity.TimeElapsed = request.TimeElapsed;

            var iditem = this._gameMetricDomainRepository.CreateMetric(entity);

            response.Id = iditem;
            response.GameId = entity.GameId;
            response.UserId = entity.UserId;
            response.ClassId = entity.ClassId;
            response.Score = entity.Score;
            response.TimeElapsed = entity.TimeElapsed;

            return response;
        }

        public bool DeleteGameMetricById(int id) {

            var entity = this._gameMetricDomainRepository.GetMetricById(id);
            if (entity == null)
            {
                return false;
            }
            this._gameMetricDomainRepository.DeleteMetric(entity.Id);
            return true;

        }
        public GetGameMetricResponse GetGameMetricById(int id) {

            var response = new GetGameMetricResponse();
            var entity = this._gameMetricDomainRepository.GetMetricById(id);
            if (entity == null)
            {
                throw new Exception("Game metric not found!");
            }

            response.Id = entity.Id;
            response.GameId = entity.GameId;
            response.UserId = entity.UserId;
            response.ClassId = entity.ClassId;
            response.Score = entity.Score;
            response.TimeElapsed = entity.TimeElapsed;


            return response;
        }

        public List<GetGameMetricResponse> GetAllGameMetrics() { 
        
            var responseLs = new List<GetGameMetricResponse>();
            var metricLs = this._gameMetricDomainRepository.GetAllMetrics();

            foreach (var item in metricLs) { 

                var metric = new GetGameMetricResponse();
                metric.Id = item.Id;
                metric.GameId = item.GameId;
                metric.UserId = item.UserId;
                metric.ClassId = item.ClassId;
                metric.Score = item.Score;
                metric.TimeElapsed = item.TimeElapsed;

                responseLs.Add(metric);
            }

            return responseLs;
        }

        public GetGameMetricResponse EditGameInfo(UpdateGameMetricRequest request) { 
        
            var response = new GetGameMetricResponse();

            var entity = this._gameMetricDomainRepository.GetMetricById(request.Id);
            if (entity == null)
            {
                throw new Exception("Game metric not found!");
            }

            entity.GameId = request.GameId;
            entity.UserId = request.UserId;
            entity.ClassId = request.ClassId;
            entity.Score = request.Score;
            entity.TimeElapsed = request.TimeElapsed;

            this._gameMetricDomainRepository.Update(entity);

            response.Id = entity.Id;
            response.GameId = entity.GameId;
            response.UserId = entity.UserId;
            response.ClassId = entity.ClassId;
            response.Score = entity.Score;
            response.TimeElapsed = entity.TimeElapsed;

            return response;

        }
    }
}
