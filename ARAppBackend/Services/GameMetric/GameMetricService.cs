using ARAppBackend.DTOs.GameMetric;
using Domain.Entities;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {
        public GetGameMetricResponse CreateGameMetric(CreateGameMetricRequest request)
        {

            var response = new GetGameMetricResponse();
            GameMetricEntity entity = new GameMetricEntity();

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

            var iditem = this._gameMetricDomainRepository.CreateMetric(entity);

            response.Id = iditem;
            response.GameId = entity.GameId;
            response.UserId = entity.UserId;
            response.ClassId = entity.ClassId;
            response.Score = entity.Score;
            response.TimeElapsed = entity.TimeElapsed;

            return response;
        }

        public bool DeleteGameMetricById(int id)
        {

            var entity = this._gameMetricDomainRepository.GetMetricById(id);
            if (entity == null)
            {
                return false;
            }
            this._gameMetricDomainRepository.DeleteMetric(entity.Id);
            return true;

        }
        public GetGameMetricResponse GetGameMetricById(int id)
        {

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

        public List<GetGameMetricResponse> GetAllGameMetrics()
        {

            var responseLs = new List<GetGameMetricResponse>();
            var metricLs = this._gameMetricDomainRepository.GetAllMetrics();

            foreach (var item in metricLs)
            {

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

        public GetGameMetricResponse EditGameMetricInfo(UpdateGameMetricRequest request)
        {

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


            this._gameMetricDomainRepository.UpdateSync(entity);

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

        //1 CLASS
        //0 USER
        public RatioSuccessFailResponse ElapsedTimeByClassOrUser(int userOrClass, string difficulty, int userOrClassId) {

            RatioSuccessFailResponse classOrUserRatio = new RatioSuccessFailResponse();
            List<ValueRatioSuccessFail> ls = new List<ValueRatioSuccessFail>();

            if (userOrClass == 1)
            {
                var query = this._gameMetricDomainRepository.GetMetricsByClassId(userOrClassId).Where(x => x.Difficulty == difficulty).OrderByDescending(x => x.FailureCount);
                classOrUserRatio.Name = GetClassById(userOrClassId).Code;
                foreach (var i in query)
                {
                    ValueRatioSuccessFail value = new ValueRatioSuccessFail();
                    var currentUser = GetUserById(i.UserId);
                    value.Name = string.Concat(currentUser.Firstname, " ", currentUser.Lastname);
                    value.Value = float.Parse(i.TimeElapsed);
                    ls.Add(value);
                }
            }
            else {

                var query = this._gameMetricDomainRepository.GetMetricsByUserId(userOrClassId).Where(x => x.Difficulty == difficulty).OrderByDescending(x => x.FailureCount);
                var currentUser = GetUserById(userOrClassId);
                classOrUserRatio.Name = string.Concat(currentUser.Firstname, " ", currentUser.Lastname);
                foreach (var i in query)
                {
                    ValueRatioSuccessFail value = new ValueRatioSuccessFail();
                    value.Name = GetClassById(i.ClassId).Code;
                    value.Value = float.Parse(i.TimeElapsed);
                    ls.Add(value);
                }

            }
            return classOrUserRatio;
        }

        //1 CLASS
        //0 USER
        //1 FAIL
        //0 SUCCESS
        public RatioSuccessFailResponse GetMostFailsOrSuccessByClassOrUser(int userOrClass, int failOrSuccess, string difficulty, int userOrClassId)
        {

            RatioSuccessFailResponse classOrUserRatio = new RatioSuccessFailResponse();
            List<ValueRatioSuccessFail> ls = new List<ValueRatioSuccessFail>();


            if (userOrClass == 1)
            {
                var query = this._gameMetricDomainRepository.GetMetricsByClassId(userOrClassId).Where(x => x.Difficulty == difficulty).OrderByDescending(x => x.FailureCount);
                classOrUserRatio.Name = GetClassById(userOrClassId).Code;
                foreach (var i in query)
                {
                    ValueRatioSuccessFail value = new ValueRatioSuccessFail();
                    var currentUser = GetUserById(i.UserId);
                    value.Name = string.Concat(currentUser.Firstname, " ", currentUser.Lastname);
                    value.Value = (failOrSuccess == 1) ? (float)i.FailureCount : (float)i.SuccessCount;
                    ls.Add(value);
                }

            }
            else
            {
                var query = this._gameMetricDomainRepository.GetMetricsByUserId(userOrClassId).Where(x => x.Difficulty == difficulty).OrderByDescending(x => x.FailureCount);
                var currentUser = GetUserById(userOrClassId);
                classOrUserRatio.Name = string.Concat(currentUser.Firstname, " ", currentUser.Lastname);
                foreach (var i in query)
                {
                    ValueRatioSuccessFail value = new ValueRatioSuccessFail();
                    value.Name = GetClassById(i.ClassId).Code;
                    value.Value = (failOrSuccess == 1) ? (float)i.FailureCount : (float)i.SuccessCount;
                    ls.Add(value);
                }
            }

            classOrUserRatio.series = ls;

            return classOrUserRatio;
        }

        public RatioSuccessFailResponse RatioSuccessFailReportByClassId(int classId, string difficulty)
        {
            var response = new RatioSuccessFailResponse();
            var valLs = new List<ValueRatioSuccessFail>();

            var query = this._gameMetricDomainRepository.GetMetricsByClassId(classId);

            var q2 = query.Where(x => x.Difficulty == difficulty).GroupBy(x => x.UserId).Select(x => new
            {

                Username = this._userDomainRepository.GetUserById(x.Select(z => z.UserId).FirstOrDefault()).Firstname,
                Success = (int)x.Sum(z => z.SuccessCount),
                Fails = (int)x.Sum(z => z.FailureCount),
                totalTries = (int)x.Sum(z => z.SuccessCount) + (int)x.Sum(z => z.FailureCount),
                ratioSuccessFail = ((int)x.Sum(z => z.SuccessCount) + (int)x.Sum(z => z.FailureCount)) > 0 ? (int)Math.Round((double)((int)x.Sum(z => z.SuccessCount)) / ((int)x.Sum(z => z.SuccessCount) + (int)x.Sum(z => z.FailureCount)) * 100) : 0

            }).ToList();

            foreach (var ratio in q2)
            {

                ValueRatioSuccessFail dto = new ValueRatioSuccessFail();
                dto.Name = ratio.Username;
                dto.Value = ratio.ratioSuccessFail;
                valLs.Add(dto);

            }
            response.Name = this._classDomainRepository.GetClassById(classId).ClassName;
            response.series = valLs;

            return response;
        }

        public RatioSuccessFailResponse RatioSuccessFailReportByUserId(int userId , string difficulty)
        {


            var response = new RatioSuccessFailResponse();
            var valLs = new List<ValueRatioSuccessFail>();

            var query = this._gameMetricDomainRepository.GetMetricsByUserId(userId);

            var q2 = query.Where(x => x.Difficulty == difficulty).GroupBy(x => x.UserId).Select(x => new
            {

                Classname = this._classDomainRepository.GetClassById(x.Select(z => z.ClassId).FirstOrDefault()).ClassName,
                Succes = (int)x.Sum(z => z.SuccessCount),
                Fails = (int)x.Sum(z => z.FailureCount),
                totalTries = (int)x.Sum(z => z.SuccessCount) + (int)x.Sum(z => z.FailureCount),
                ratioSuccessFail = ((int)x.Sum(z => z.SuccessCount) + (int)x.Sum(z => z.FailureCount)) > 0 ? (int)Math.Round((double)((int)x.Sum(z => z.SuccessCount)) / ((int)x.Sum(z => z.SuccessCount) + (int)x.Sum(z => z.FailureCount)) * 100) : 0

            }).ToList();

            foreach (var ratio in q2)
            {

                ValueRatioSuccessFail dto = new ValueRatioSuccessFail();
                dto.Name = ratio.Classname;
                dto.Value = ratio.ratioSuccessFail;
                valLs.Add(dto);

            }
            var user = this._userDomainRepository.GetUserById(userId);
            response.Name = String.Concat(user.Firstname + " " + user.Lastname);
            response.series = valLs;

            return response;
        }
    }
}
