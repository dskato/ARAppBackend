
using Domain.Entities;

namespace ARAppBackend
{
    public partial interface IApplicationService
    {
        string CreateToken(UserEntity user);
    }
}
