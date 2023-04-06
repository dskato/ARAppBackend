using ARAppBackend.DTOs.GameMetric;

namespace ARAppBackend
{
    public partial interface IApplicationService
    {
        GetGameMetricResponse CreateGame(CreateGameMetricRequest request);
        bool DeleteGameMetricById(int id);
        GetGameMetricResponse GetGameMetricById(int id);
        List<GetGameMetricResponse> GetAllGameMetrics();
        GetGameMetricResponse EditGameInfo(UpdateGameMetricRequest request);
    }
}
