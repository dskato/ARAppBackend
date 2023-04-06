namespace ARAppBackend.DTOs.Class
{
    public class UpdateClassRequest
    {
        public int Id { get; set; }
        public int? GameId { get; set; }
        public string? ClassName { get; set; }
        public string? UserListId { get; set; }
    }
}
