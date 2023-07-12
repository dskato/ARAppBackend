using ARAppBackend.DTOs.GameMetric;

namespace ARAppBackend
{
    public partial interface IApplicationService
    {
        GetGameMetricResponse CreateGameMetric(CreateGameMetricRequest request);
        bool DeleteGameMetricById(int id);
        GetGameMetricResponse GetGameMetricById(int id);
        List<GetGameMetricResponse> GetAllGameMetrics();
        GetGameMetricResponse EditGameMetricInfo(UpdateGameMetricRequest request);
        RatioSuccessFailResponse RatioSuccessFailReportByClassId(int classId, string difficulty);
        RatioSuccessFailResponse RatioSuccessFailReportByUserId(int userId, string difficulty);
        RatioSuccessFailResponse GetMostFailsOrSuccessByClassOrUser(int userOrClass, int failOrSuccess, int gameId, string difficulty, int userOrClassId);
        RatioSuccessFailResponse ElapsedTimeByClassOrUser(int userOrClass, string difficulty, int userOrClassId);
        RatioSuccessFailResponse GeneralRanking(int userOrClass, int gameId, string difficulty, int userOrClassId);
    }
}
