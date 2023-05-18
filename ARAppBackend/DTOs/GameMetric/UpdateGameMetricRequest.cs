namespace ARAppBackend.DTOs.GameMetric
{
    public class UpdateGameMetricRequest
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public string Score { get; set; }
        public string TimeElapsed { get; set; }
        public bool IsGameCompleted { get; set; }
        public double? PercentageOfCompletion { get; set; }
        public int? SuccessCount { get; set; }
        public int? FailureCount { get; set; }
        public string? Difficulty { get; set; }
        public string? Comments { get; set; }
    }
}
