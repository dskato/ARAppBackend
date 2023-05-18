using ARAppBackend.DTOs.GameMetric;
using Domain.Entities;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {
        public GetGameMetricResponse CreateGameMetric(CreateGameMetricRequest request) { 

            var response = new GetGameMetricResponse();
            GameMetricEntity entity = new GameMetricEntity();

            entity.GameId = request.GameId;
            entity.UserId = request.UserId;
            entity.ClassId = request.ClassId;
            entity.Score = request.Score;
            entity.TimeElapsed = request.TimeElapsed;
            entity.IsGameCompleted = request.IsGameCompleted;
            entity.PercentageOfCompletion  = request.PercentageOfCompletion;
            entity.SuccessCount = request.SuccessCount;
            entity.FailureCount = request.FailureCount;
            entity.Difficulty  = request.Difficulty;
            entity.Comments = request.Comments;

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
            response.IsGameCompleted = entity.IsGameCompleted;
            response.PercentageOfCompletion = entity.PercentageOfCompletion;
            response.SuccessCount = entity.SuccessCount;
            response.FailureCount = entity.FailureCount;
            response.Difficulty = entity.Difficulty;
            response.Comments = entity.Comments;



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
                metric.IsGameCompleted = item.IsGameCompleted;
                metric.PercentageOfCompletion = item.PercentageOfCompletion;
                metric.SuccessCount = item.SuccessCount;
                metric.FailureCount = item.FailureCount;
                metric.Difficulty = item.Difficulty;
                metric.Comments = item.Comments;

                responseLs.Add(metric);
            }

            return responseLs;
        }

        public GetGameMetricResponse EditGameMetricInfo(UpdateGameMetricRequest request) { 
        
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
            entity.IsGameCompleted = request.IsGameCompleted;
            entity.PercentageOfCompletion = request.PercentageOfCompletion;
            entity.SuccessCount = request.SuccessCount;
            entity.FailureCount = request.FailureCount;
            entity.Difficulty = request.Difficulty;
            entity.Comments = request.Comments;


            this._gameMetricDomainRepository.Update(entity);

            response.Id = entity.Id;
            response.GameId = entity.GameId;
            response.UserId = entity.UserId;
            response.ClassId = entity.ClassId;
            response.Score = entity.Score;
            response.TimeElapsed = entity.TimeElapsed;
            response.IsGameCompleted = entity.IsGameCompleted;
            response.PercentageOfCompletion = entity.PercentageOfCompletion;
            response.SuccessCount = entity.SuccessCount;
            response.FailureCount = entity.FailureCount;
            response.Difficulty = entity.Difficulty;
            response.Comments = entity.Comments;

            return response;

        }
    }
}
