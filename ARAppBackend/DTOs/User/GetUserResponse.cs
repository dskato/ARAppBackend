﻿namespace ARAppBackend.DTOs.User
{
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
