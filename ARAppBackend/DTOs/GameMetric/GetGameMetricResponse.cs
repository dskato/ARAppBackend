namespace ARAppBackend.DTOs.GameMetric
{
    public class GetGameMetricResponse
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public string Score { get; set; }
        public string TimeElapsed { get; set; }
    }
}
