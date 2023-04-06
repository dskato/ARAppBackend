namespace ARAppBackend.DTOs.Games
{
    public class UpdateGameRequest
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string Difficulty { get; set; }
    }
}
