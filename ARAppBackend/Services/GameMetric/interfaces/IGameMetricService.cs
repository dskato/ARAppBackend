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
    }
}
