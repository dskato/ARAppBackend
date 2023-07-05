using ARAppBackend.DTOs.Class;
using ARAppBackend.DTOs.User;
using Domain.Entities;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {

        public void AddUserInClass(int userId, string classCode)
        {
            var classEntity = GetClassByCode(classCode);
            if (classEntity == null)
            {
                throw new Exception("Class not found!");
            }
            var userEntity = GetUserById(userId);
            if (userEntity == null)
            {
                throw new Exception("User not found!");
            }
            if (this._mClassUserDomainRepository.UserExistInClass(userId))
            {
                throw new Exception("User already in class!");
            }
            MClassUserEntity entity = new MClassUserEntity();
            entity.UserId = userId;
            entity.ClassId = classEntity.Id;
            this._mClassUserDomainRepository.AddSync(entity);

        }
        public List<GetUserResponse> GetUsersInClassByClassId(int classId)
        {
            List<GetUserResponse> userDtoLs = new List<GetUserResponse>();

            var mClassUser = this._mClassUserDomainRepository.GetUsersByClassId(classId);
            foreach (var ids in mClassUser)
            {

                var user = GetUserById(ids.UserId);

                GetUserResponse dto = new GetUserResponse();
                dto.Id = user.Id;
                dto.Firstname = user.Firstname;
                dto.Lastname = user.Lastname;
                dto.Role = user.Role;
                dto.Email = user.Email;
                dto.Age = user.Age;
                dto.Status = user.Status;


                userDtoLs.Add(dto);
            }

            return userDtoLs;
        }
        public List<GetClassResponse> GetClassesOfUserByUserId(int userId)
        {
            List<GetClassResponse> classDtoLs = new List<GetClassResponse>();

            var mClassUser = this._mClassUserDomainRepository.GetClassesByUserId(userId);
            foreach (var ids in mClassUser)
            {

                var classItem = GetClassById(ids.ClassId);

                GetClassResponse dto = new GetClassResponse();
                dto.ClassName = classItem.ClassName;
                dto.Code = classItem.Code;
                dto.Id = classItem.Id;
                dto.Grade = classItem.Grade;

                classDtoLs.Add(dto);
            }


            return classDtoLs;
        }

        public List<MClassUserEntity> GetAllMCU()
        {

            return this._mClassUserDomainRepository.GetAllMCU();
        }
    }
}
