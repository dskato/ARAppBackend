using ARAppBackend.DTOs.Class;
using ARAppBackend.DTOs.User;

namespace ARAppBackend
{
    public partial interface IApplicationService
    {
        void AddUserInClass(int userId, string classCode);
        List<GetUserResponse> GetUsersInClassByClassId(int classId);
        List<GetClassResponse> GetClassesOfUserByUserId(int userId);
    }
}
