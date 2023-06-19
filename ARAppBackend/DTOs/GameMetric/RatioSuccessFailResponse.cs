namespace ARAppBackend.DTOs.GameMetric
{
    public class RatioSuccessFailResponse
    {
        public string Name { get; set; }
        public List<ValueRatioSuccessFail> series { get; set; } 
    }
}
