using ARAppBackend.DTOs.User;
using ARAppBackend.Utils;
using Domain.Entities;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {

        public GetUserResponse CreateUser(CreateUserRequest request)
        {

            var response = new GetUserResponse();
            if (UserExists(request.Email) == true)
            {
                throw new Exception("Email is taken!");
            }

            PasswordUtils.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            UserEntity user = new UserEntity();
            user.Firstname = request.Firstname;
            user.Lastname = request.Lastname;
            user.Email = request.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Role = request.Role;
            user.CreateDate = DateTime.UtcNow;

            var userId = this._userDomainRepository.CreateUser(user);

            response.Id = userId;
            response.Firstname = user.Firstname;
            response.Lastname = user.Lastname;
            response.Email = user.Email;


            return response;
        }

        public GetUserResponse GetUserById(int id)
        {

            GetUserResponse response = new GetUserResponse();

            var user = this._userDomainRepository.GetUserById(id);
            if (user == null)
            {
                throw new Exception("User not exists!");
            }

            response.Id = user.Id;
            response.Firstname = user.Firstname;
            response.Lastname = user.Lastname;
            response.Email = user.Email;

            return response;
        }

        public GetUserResponse LogIn(string email, string password)
        {

            GetUserResponse response = new GetUserResponse();

            var user = this._userDomainRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("Incorrect email or password");
            }
            if (!PasswordUtils.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Incorrect email or password");
            }
            response.Id = user.Id;
            response.Firstname = user.Firstname;
            response.Lastname = user.Lastname;
            response.Email = user.Email;
            response.Token = CreateToken(user);


            return response;
        }

        public GetUserResponse GetUserByEmail(string email)
        {

            GetUserResponse response = new GetUserResponse();

            var user = this._userDomainRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("User not exists!");
            }

            response.Id = user.Id;
            response.Firstname = user.Firstname;
            response.Lastname = user.Lastname;
            response.Email = user.Email;

            return response;
        }

        public bool UpdateUserById(UpdateUserRequest request)
        {
            var user = this._userDomainRepository.GetUserById(request.Id);
            if (user == null)
            {
                return false;
            }

            user.Firstname = request.Firstname;
            user.Lastname = request.Lastname;
            user.Email = request.Email;
            user.Role = request.Role;

            this._userDomainRepository.Update(user);


            return true;

        }
        public bool DeleteUserById(int id)
        {

            var user = this._userDomainRepository.GetUserById(id);
            if (user == null)
            {
                return false;
            }

            var res = this._userDomainRepository.DeleteUser(id);
            if (res)
            {
                return true;
            }
            return false;

        }

        public List<GetUserResponse> GetAllUsers()
        {

            List<GetUserResponse> response = new List<GetUserResponse>();

            var users = this._userDomainRepository.GetAllUsers();
            foreach (var user in users)
            {

                GetUserResponse item = new GetUserResponse();
                item.Id = user.Id;
                item.Firstname = user.Firstname;
                item.Lastname = user.Lastname;
                item.Email = user.Email;
                item.Role = user.Role;
                item.CreateDate = user.CreateDate;
                response.Add(item);

            }

            return response;

        }

        public bool ForgotPassword(string email, string newPassword)
        {

            PasswordUtils.CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            var passChange = this._userDomainRepository.ForgotPassword(email, passwordHash, passwordSalt);
            return passChange;

        }

        private bool UserExists(string email)
        {
            var user = this._userDomainRepository.GetUserByEmail(email);
            if (user != null)
            {
                return true;
            }
            return false;

        }
    }
}
