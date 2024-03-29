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
        public RatioSuccessFailResponse ElapsedTimeByClassOrUser(int userOrClass, string difficulty, int userOrClassId)
        {

            RatioSuccessFailResponse classOrUserRatio = new RatioSuccessFailResponse();
            List<ValueRatioSuccessFail> ls = new List<ValueRatioSuccessFail>();

            if (userOrClass == 1)
            {
                var query = this._gameMetricDomainRepository.GetMetricsByClassId(userOrClassId).Where(x => x.Difficulty == difficulty).OrderByDescending(x => x.FailureCount);
                classOrUserRatio.Name = GetClassById(userOrClassId).Code + " - " + difficulty;
                foreach (var i in query)
                {
                    var currentUser = GetUserById(i.UserId);
                    string name = string.Concat(currentUser.Firstname, " ", currentUser.Lastname);
                    var existingValue = ls.FirstOrDefault(x => x.Name == name);

                    if (existingValue != null)
                        existingValue.Value += float.Parse(i.TimeElapsed);
                    else
                    {
                        ValueRatioSuccessFail value = new ValueRatioSuccessFail();
                        value.Name = name;
                        value.Value = float.Parse(i.TimeElapsed);
                        ls.Add(value);
                    }
                }
            }
            else
            {

                var query = this._gameMetricDomainRepository.GetMetricsByUserId(userOrClassId).Where(x => x.Difficulty == difficulty).OrderByDescending(x => x.FailureCount);
                var currentUser = GetUserById(userOrClassId);
                classOrUserRatio.Name = string.Concat(currentUser.Firstname, " ", currentUser.Lastname) + " - " + difficulty;
                foreach (var i in query)
                {
                    string name = GetClassById(i.ClassId).Code;
                    var existingValue = ls.FirstOrDefault(x => x.Name == name);

                    if (existingValue != null)
                        existingValue.Value += float.Parse(i.TimeElapsed);
                    else
                    {
                        ValueRatioSuccessFail value = new ValueRatioSuccessFail();
                        value.Name = name;
                        value.Value = float.Parse(i.TimeElapsed);
                        ls.Add(value);
                    }
                }

            }

            classOrUserRatio.series = ls;
            return classOrUserRatio;
        }

        //1 CLASS
        //0 USER
        //1 FAIL
        //0 SUCCESS
        public RatioSuccessFailResponse GetMostFailsOrSuccessByClassOrUser(int userOrClass, int failOrSuccess, int gameId, string difficulty, int userOrClassId)
        {

            RatioSuccessFailResponse classOrUserRatio = new RatioSuccessFailResponse();
            List<ValueRatioSuccessFail> ls = new List<ValueRatioSuccessFail>();


            if (userOrClass == 1)
            {
                var query = this._gameMetricDomainRepository.GetMetricsByClassId(userOrClassId).Where(x => x.Difficulty == difficulty && x.GameId == gameId).OrderByDescending(x => x.FailureCount);
                classOrUserRatio.Name = GetClassById(userOrClassId).Code + " - " + difficulty;
                foreach (var i in query)
                {
                    var currentUser = GetUserById(i.UserId);
                    string name = string.Concat(currentUser.Firstname, " ", currentUser.Lastname);
                    var existingValue = ls.FirstOrDefault(x => x.Name == name);

                    if (existingValue != null)
                    {
                        if (failOrSuccess == 1)
                            existingValue.Value += (float)i.FailureCount;
                        else
                            existingValue.Value += (float)i.SuccessCount;
                    }
                    else
                    {
                        ValueRatioSuccessFail value = new ValueRatioSuccessFail();
                        value.Name = name;
                        value.Value = (failOrSuccess == 1) ? (float)i.FailureCount : (float)i.SuccessCount;
                        ls.Add(value);
                    }
                }

            }
            else
            {
                var query = this._gameMetricDomainRepository.GetMetricsByUserId(userOrClassId).Where(x => x.Difficulty == difficulty).OrderByDescending(x => x.FailureCount);
                var currentUser = GetUserById(userOrClassId);
                classOrUserRatio.Name = string.Concat(currentUser.Firstname, " ", currentUser.Lastname) + " - " + difficulty;
                foreach (var i in query)
                {
                    string name = GetClassById(i.ClassId).Code;
                    var existingValue = ls.FirstOrDefault(x => x.Name == name);

                    if (existingValue != null)
                    {
                        if (failOrSuccess == 1)
                            existingValue.Value += (float)i.FailureCount;
                        else
                            existingValue.Value += (float)i.SuccessCount;
                    }
                    else
                    {
                        ValueRatioSuccessFail value = new ValueRatioSuccessFail();
                        value.Name = name;
                        value.Value = (failOrSuccess == 1) ? (float)i.FailureCount : (float)i.SuccessCount;
                        ls.Add(value);
                    }
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
            response.Name = this._classDomainRepository.GetClassById(classId).ClassName + " - " + difficulty;
            response.series = valLs;

            return response;
        }

        public RatioSuccessFailResponse RatioSuccessFailReportByUserId(int userId, string difficulty)
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
            response.Name = String.Concat(user.Firstname + " " + user.Lastname) + " - " + difficulty;
            response.series = valLs;

            return response;
        }

        //1 CLASS
        //0 USER
        public RatioSuccessFailResponse GeneralRanking(int userOrClass, int gameId, string difficulty, int userOrClassId)
        {
            RatioSuccessFailResponse generalRanking = new RatioSuccessFailResponse();
            List<ValueRatioSuccessFail> ls = new List<ValueRatioSuccessFail>();

            Dictionary<string, double> userScores = new Dictionary<string, double>();

            if (userOrClass == 1)
            {
                var query = this._gameMetricDomainRepository.GetMetricsByClassId(userOrClassId).Where(x => x.Difficulty == difficulty && x.GameId == gameId).OrderByDescending(x => x.FailureCount);

                generalRanking.Name = GetClassById(userOrClassId).Code + " - " + difficulty;

                foreach (var metric in query)
                {
                    var currentUser = GetUserById(metric.UserId);
                    string name = string.Concat(currentUser.Firstname, " ", currentUser.Lastname);

                    if (userScores.ContainsKey(name))
                    {
                        userScores[name] += GenerateRanking(double.Parse(metric.Score), double.Parse(metric.TimeElapsed), (int)metric.SuccessCount, (int)metric.FailureCount);
                    }
                    else
                    {
                        userScores[name] = GenerateRanking(double.Parse(metric.Score), double.Parse(metric.TimeElapsed), (int)metric.SuccessCount, (int)metric.FailureCount);
                    }
                }
            }
            else
            {
                var query = this._gameMetricDomainRepository.GetMetricsByUserId(userOrClassId).Where(x => x.Difficulty == difficulty && x.GameId == gameId).OrderByDescending(x => x.FailureCount);

                var currentUser = GetUserById(userOrClassId);
                generalRanking.Name = string.Concat(currentUser.Firstname, " ", currentUser.Lastname) + " - " + difficulty;

                foreach (var metric in query)
                {
                    string name = GetClassById(metric.ClassId).Code;

                    if (userScores.ContainsKey(name))
                    {
                        userScores[name] += GenerateRanking(double.Parse(metric.Score), double.Parse(metric.TimeElapsed), (int)metric.SuccessCount, (int)metric.FailureCount);
                    }
                    else
                    {
                        userScores[name] = GenerateRanking(double.Parse(metric.Score), double.Parse(metric.TimeElapsed), (int)metric.SuccessCount, (int)metric.FailureCount);
                    }
                }
            }

            foreach (var entry in userScores)
            {
                ValueRatioSuccessFail value = new ValueRatioSuccessFail();
                value.Name = entry.Key;
                value.Value = (float)entry.Value;
                ls.Add(value);
            }

            generalRanking.series = ls;
            return generalRanking;
        }

        public List<ValueRatioSuccessFail> GenerateGeneralInfo(int userId)
        {
            List<ValueRatioSuccessFail> lsInfo = new List<ValueRatioSuccessFail>();
            ValueRatioSuccessFail dto = new ValueRatioSuccessFail();
            var user = this._userDomainRepository.GetUserById(userId);
            var userCompleteName = String.Concat(user.Firstname, " ", user.Lastname);

            List<ValueRatioSuccessFail> valueLs = new List<ValueRatioSuccessFail>();

            var teacherClassesIds = this._mClassUserDomainRepository
                .GetClassesByUserId(userId)
                .Where(x => x.UserId == userId)
                .Select(x => x.ClassId)
                .Distinct()
                .ToList();

            List<int> userIds = new List<int>();
            foreach (var tc in teacherClassesIds)
            {
                var uids = this._mClassUserDomainRepository.GetUsersByClassId(tc).Select(x => x.UserId).Distinct().ToList();
                userIds.AddRange(uids);
            }
            var userIdsCounts = userIds.Distinct().ToList().Count();

            //Count active students
            dto.Name = "Usuarios Activos";
            dto.Value = userIdsCounts;
            lsInfo.Add(dto);

            //Count all classes created
            dto = new ValueRatioSuccessFail();
            dto.Name = "Clases creadas";
            dto.Value = this._classDomainRepository.GetAllClasses().Count();
            lsInfo.Add(dto);

            //Count teacher classes created
            dto = new ValueRatioSuccessFail();
            dto.Name = String.Concat("Clases creadas por: ", userCompleteName);
            dto.Value = this._mClassUserDomainRepository.GetClassesByUserId(userId).Count();
            lsInfo.Add(dto);

            //Count all games created
            dto = new ValueRatioSuccessFail();
            dto.Name = "Juegos Activos";
            dto.Value = this._gameDomainRepository.GetAllGames().Count();
            lsInfo.Add(dto);

            //Count all the time hours played in teacher clasess
            dto = new ValueRatioSuccessFail();
            var teacherClasessIds = this._mClassUserDomainRepository.GetClassesByUserId(userId).Select(x => x.ClassId).Distinct().ToList();
            var lsPlayedHours = this._gameMetricDomainRepository.GetAllMetrics().Where(x => teacherClasessIds.Contains(x.ClassId)).Select(y => double.Parse(y.TimeElapsed)).ToList();
            double totalSeconds = lsPlayedHours.Sum();

            dto.Name = "Horas totales jugadas en sus clases";
            dto.Value = (float)totalSeconds;
            lsInfo.Add(dto);


            return lsInfo;
        }

        //1 FAIL
        //0 SUCCESS
        public List<ValueRatioSuccessFail> GetTeacherStudentsFailOrSuccessCount(int userId, int failOrSuccess)
        {
            List<ValueRatioSuccessFail> valueLs = new List<ValueRatioSuccessFail>();

            var teacherClassesIds = this._mClassUserDomainRepository
                .GetClassesByUserId(userId)
                .Where(x => x.UserId == userId)
                .Select(x => x.ClassId)
                .Distinct()
                .ToList();

            List<int> userIds = new List<int>();
            foreach (var tc in teacherClassesIds)
            {
                var uids = this._mClassUserDomainRepository.GetUsersByClassId(tc).Select(x => x.UserId).Distinct().ToList();
                userIds.AddRange(uids);
            }
            userIds = userIds.Distinct().ToList();
            userIds.Remove(userId);

            foreach (var u in userIds)
            {
                ValueRatioSuccessFail valDto = new ValueRatioSuccessFail();
                var user = this._userDomainRepository.GetUserById(u);
                valDto.Name = string.Concat(user.Firstname, " ", user.Lastname);

                if (failOrSuccess == 1)
                {
                    valDto.Value = this._gameMetricDomainRepository.GetMetricsByUserId(u).Select(x => x.FailureCount).Sum(x => x.Value);
                }
                else
                {
                    valDto.Value = this._gameMetricDomainRepository.GetMetricsByUserId(u).Select(x => x.SuccessCount).Sum(x => x.Value);
                }
                valueLs.Add(valDto);
            }

            return valueLs;
        }

        public List<ValueRatioSuccessFail> GetTeacherStudentsGamesPlayedCount(int userId)
        {
            List<ValueRatioSuccessFail> valueLs = new List<ValueRatioSuccessFail>();

            var teacherClassesIds = this._mClassUserDomainRepository
                .GetClassesByUserId(userId)
                .Where(x => x.UserId == userId)
                .Select(x => x.ClassId)
                .Distinct()
                .ToList();

            List<int> userIds = new List<int>();
            foreach (var tc in teacherClassesIds)
            {
                var uids = this._mClassUserDomainRepository.GetUsersByClassId(tc).Select(x => x.UserId).Distinct().ToList();
                userIds.AddRange(uids);
            }
            userIds = userIds.Distinct().ToList();
            userIds.Remove(userId);

            foreach (var u in userIds)
            {
                ValueRatioSuccessFail valDto = new ValueRatioSuccessFail();
                var user = this._userDomainRepository.GetUserById(u);
                valDto.Name = string.Concat(user.Firstname, " ", user.Lastname);
                valDto.Value = this._gameMetricDomainRepository.GetMetricsByUserId(u).Count();
                valueLs.Add(valDto);
            }

            return valueLs;
        }

        public List<ValueRatioSuccessFail> GetTeacherStudentsGamesScores(int userId)
        {
            List<ValueRatioSuccessFail> valueLs = new List<ValueRatioSuccessFail>();

            var teacherClassesIds = this._mClassUserDomainRepository
                .GetClassesByUserId(userId)
                .Where(x => x.UserId == userId)
                .Select(x => x.ClassId)
                .Distinct()
                .ToList();

            List<int> userIds = new List<int>();
            foreach (var tc in teacherClassesIds)
            {
                var uids = this._mClassUserDomainRepository.GetUsersByClassId(tc).Select(x => x.UserId).Distinct().ToList();
                userIds.AddRange(uids);
            }
            userIds = userIds.Distinct().ToList();
            userIds.Remove(userId);

            foreach (var u in userIds)
            {
                ValueRatioSuccessFail valDto = new ValueRatioSuccessFail();
                var user = this._userDomainRepository.GetUserById(u);
                valDto.Name = string.Concat(user.Firstname, " ", user.Lastname);
                valDto.Value = this._gameMetricDomainRepository.GetMetricsByUserId(u).Select(x => (x.SuccessCount - x.FailureCount) ).Sum(x => x.Value);
                valueLs.Add(valDto);
            }

            return valueLs;
        }

    private double GenerateRanking(double score, double timeElapsed, int success, int fails)
        {
            double timeWeight = timeElapsed != 0 ? (0.3 * (1.0 / timeElapsed)) : 0.0;
            double failsWeight = fails != 0 ? (0.1 * (1.0 / fails)) : 0.0;

            return ((0.4 * score) + timeWeight + (0.2 * success) + failsWeight);
        }
    }

}
