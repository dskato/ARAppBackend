using Domain.Entities;
using Domain.Interfaces.Generics;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Generic;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : GenericDataDbRepository<UserEntity>, IUserDomainRepository
    {
        public UserRepository(AppDbContext contex) : base(contex)
        {
            Context = contex;
        }

        public int CreateUser(UserEntity user)
        {
            this.AddSync(user);
            return user.Id;
        }

        public bool DeleteUser(int id)
        {
            var user = this.GetUserById(id);
            if (user != null)
            {
                this.RemoveSync(user);
                return true;
            }
            return false;
        }

        public bool ForgotPassword(string email, byte[] passwordHash, byte[] passwordSalt)
        {
            var user = GetUserByEmail(email);
            if (user == null) {
                return false;
            }
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            Update(user);

            return true;
        }

        public List<UserEntity> GetAllUsers()
        {
            var userLs = this.Context.UserEntity.ToList();
            return userLs;
        }

        public UserEntity GetUserByEmail(string email)
        {
            var user = this.Context.UserEntity.Where(x => x.Email == email).FirstOrDefault();
            return user;
        }

        public UserEntity GetUserById(int id)
        {
            var user = this.Context.UserEntity.Where(x => x.Id == id).FirstOrDefault();
            return user;
        }

      
    }
}
