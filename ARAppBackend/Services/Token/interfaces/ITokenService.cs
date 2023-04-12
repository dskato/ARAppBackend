using ARAppBackend.DTOs.User;

namespace ARAppBackend
{
    public partial interface IApplicationService
    {
        string CreateToken(CreateUserRequest user);
    }
}
