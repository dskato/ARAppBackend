using ARAppBackend.DTOs.Class;
using Domain.Entities;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {
        public GetClassResponse CreateClass(CreateClassRequest request)
        {

            GetClassResponse response = new GetClassResponse();
            ClassEntity classEntity = new ClassEntity();

            classEntity.GameId = request.GameId;
            classEntity.ClassName = request.ClassName;
            classEntity.UserListId = request.UserListId;

            var itemId = this._classDomainRepository.CreateClass(classEntity);

            response.Id = itemId;
            response.GameId = classEntity.GameId;
            response.ClassName = classEntity.ClassName;
            response.UserListId = classEntity.UserListId;

            return response;

        }

        public bool DeleteClassById(int id)
        {
            var item = this._classDomainRepository.GetClassById(id);
            if (item == null)
            {
                return false;
            }
            this._classDomainRepository.DeleteClass(id);
            return true;
        }

        public GetClassResponse GetClassById(int id)
        {

            var classEntity = this._classDomainRepository.GetClassById(id);
            if (classEntity == null)
            {
                throw new Exception("Class not found!");
            }
            GetClassResponse response = new GetClassResponse();

            response.Id = classEntity.Id;
            response.GameId = classEntity.GameId;
            response.ClassName = classEntity.ClassName;
            response.UserListId = classEntity.UserListId;

            return response;
        }

        public List<GetClassResponse> GetAllClasses()
        {

            List<GetClassResponse> classResponsesLs = new List<GetClassResponse>();
            var classLs = this._classDomainRepository.GetAllClasses();

            foreach (var item in classLs)
            {
                GetClassResponse response = new GetClassResponse();

                response.Id = item.Id;
                response.GameId = item.GameId;
                response.ClassName = item.ClassName;
                response.UserListId = item.UserListId;

                classResponsesLs.Add(response);
            }
            return classResponsesLs;

        }

        public GetClassResponse EditClassInfo(UpdateClassRequest request)
        {

            var classEntity = this._classDomainRepository.GetClassById(request.Id);
            if (classEntity == null)
            {
                throw new Exception("Class not found!");
            }

            classEntity.GameId = (int)request.GameId;
            classEntity.ClassName = request.ClassName;
            classEntity.UserListId = request.UserListId;
            this._classDomainRepository.Update(classEntity);


            GetClassResponse response = new GetClassResponse();
            response.Id = classEntity.Id;
            response.GameId = classEntity.GameId;
            response.ClassName = classEntity.ClassName;
            response.UserListId = classEntity.UserListId;

            return response;
        }
    }
}
