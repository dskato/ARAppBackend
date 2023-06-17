using ARAppBackend.DTOs.User;

namespace ARAppBackend
{
    public partial interface IApplicationService
    {
        GetUserResponse CreateUser(CreateUserRequest request);
        GetUserResponse LogIn(string email, string password);
        GetUserResponse GetUserById(int id);
        GetUserResponse GetUserByEmail(string email);
        bool DeleteUserById(int id);
        List<GetUserResponse> GetAllUsers();
        bool UpdateUserById(UpdateUserRequest request);
        string ChangeStatus(int id, bool isUserActive);
    }
}
