using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IUserDomainRepository : IGenericDataRepository<UserEntity>
    {
        int CreateUser(UserEntity user);
        bool DeleteUser(int id);
        UserEntity GetUserById(int id);
        UserEntity GetUserByEmail(string email);
        List<UserEntity> GetAllUsers();
        bool ForgotPassword(string email, byte[] passwordHash, byte[] passwordSalt);
        string ChangeStatus(int id, bool isUserActive);
        int CountActiveStudents();
    }
}
