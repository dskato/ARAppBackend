﻿using ARAppBackend.DTOs.User;
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
            user.Age = request.Age;
            user.Email = request.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Role = request.Role;
            user.CreateDate = DateTime.UtcNow;
            user.Status = "Active";

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
            response.Age = user.Age;
            response.Email = user.Email;
            response.Role = user.Role;


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
            response.Age = user.Age;
            response.Email = user.Email;
            response.Role = user.Role;
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
            response.Age = user.Age;
            response.Email = user.Email;
            response.Status = user.Status;
            response.Role = user.Role;

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
            user.Age = request.Age;
            user.Role = request.Role;


            this._userDomainRepository.UpdateSync(user);


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

        public List<GetUserResponse> GetAllUsers(int userId)
        {
            //First check role
            var currentUser = this._userDomainRepository.GetUserById(userId);
            var users = new List<UserEntity>();
            List<GetUserResponse> response = new List<GetUserResponse>();

            if (currentUser.Role == "TEACHER")
            {
                var teacherClassesIds = this._mClassUserDomainRepository
                .GetClassesByUserId(userId)
                .Where(x => x.UserId == userId)
                .Select(x => x.ClassId)
                .Distinct()
                .ToList();

                List<int> userIds = new List<int>();
                foreach (var tc in teacherClassesIds)
                {
                    var uids = this._mClassUserDomainRepository.GetUsersByClassId(tc).Select(x => x.UserId).Distinct().ToList();
                    userIds.AddRange(uids);
                }
                userIds = userIds.Distinct().ToList();
                userIds.Remove(userId);

                users = this._userDomainRepository.GetAllUsers().Where(x => userIds.Contains(x.Id)).ToList();
            }
            else if (currentUser.Role == "ADMIN")
            {
                users = this._userDomainRepository.GetAllUsers().ToList();
            }


            foreach (var user in users)
            {

                GetUserResponse item = new GetUserResponse();
                item.Id = user.Id;
                item.Firstname = user.Firstname;
                item.Lastname = user.Lastname;
                item.Email = user.Email;
                item.Age = user.Age;
                item.Role = user.Role;
                item.CreateDate = user.CreateDate.ToString("dd/MM/yyyy"); ;

                item.Status = user.Status;
                response.Add(item);

            }

            return response;

        }

        public List<GetUserResponse> GetAllUsersBySearchText(int userId, string textSearch)
        {
            List<GetUserResponse> response = new List<GetUserResponse>();
            var teacherClassesIds = this._mClassUserDomainRepository
                .GetClassesByUserId(userId)
                .Where(x => x.UserId == userId)
                .Select(x => x.ClassId)
                .Distinct()
                .ToList();

            List<int> userIds = new List<int>();
            foreach (var tc in teacherClassesIds)
            {
                var uids = this._mClassUserDomainRepository.GetUsersByClassId(tc).Select(x => x.UserId).Distinct().ToList();
                userIds.AddRange(uids);
            }
            userIds = userIds.Distinct().ToList();
            userIds.Remove(userId);
            var users = this._userDomainRepository.GetAllUsers().Where(x => userIds.Contains(x.Id)).ToList();


            // Filtering based on textSearch
            if (!string.IsNullOrEmpty(textSearch))
            {
                users = users.Where(user =>
                    user.Firstname.Contains(textSearch, StringComparison.OrdinalIgnoreCase) ||
                    user.Lastname.Contains(textSearch, StringComparison.OrdinalIgnoreCase) ||
                    user.Email.Contains(textSearch, StringComparison.OrdinalIgnoreCase) ||
                    user.Role.Contains(textSearch, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            foreach (var user in users)
            {
                GetUserResponse item = new GetUserResponse();
                item.Id = user.Id;
                item.Firstname = user.Firstname;
                item.Lastname = user.Lastname;
                item.Email = user.Email;
                item.Age = user.Age;
                item.Role = user.Role;
                item.CreateDate = user.CreateDate.ToString("dd/MM/yyyy");
                item.Status = user.Status;
                response.Add(item);
            }

            return response;
        }

        public string ChangeStatus(int id, bool isUserActive)
        {
            return this._userDomainRepository.ChangeStatus(id, isUserActive);
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
