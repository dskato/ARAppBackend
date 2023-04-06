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
        void DeleteUser(int id);
        void UpdateUserInfo(UserEntity user);
        UserEntity GetUserById(int id);
        UserEntity GetUserByEmail(string email);
        List<UserEntity> GetAllUsers();
        void ForgotPassword(string email);
    }
}
