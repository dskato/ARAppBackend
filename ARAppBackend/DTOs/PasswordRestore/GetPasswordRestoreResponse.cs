namespace ARAppBackend.DTOs.RestorePassword
{
    public class GetPasswordRestoreResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; }

    }
}
