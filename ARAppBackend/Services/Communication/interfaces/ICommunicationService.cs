namespace ARAppBackend
{
    public partial interface IApplicationService
    {
        Task<string> SendPasswordRecoveryEmailAsync(string email);
    }
}
