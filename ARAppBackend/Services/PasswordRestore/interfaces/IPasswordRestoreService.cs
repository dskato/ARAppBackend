using ARAppBackend.DTOs.RestorePassword;

namespace ARAppBackend
{
    public partial interface IApplicationService
    {
        Task<GetPasswordRestoreResponse> CreateCodeAsync(CreatePasswordRestoreRequest request);
        bool VerifyCode(string email, string code);

        bool ChangePassword(string email, string newPassword);
    }
}
