﻿using ARAppBackend.DTOs.Class;
using Domain.Entities;
using System.Text;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {
        public GetClassResponse CreateClass(CreateClassRequest request)
        {

            GetClassResponse response = new GetClassResponse();
            ClassEntity classEntity = new ClassEntity();
            var code = GenerateClassCode();

            classEntity.ClassName = request.ClassName;
            classEntity.Grade = request.Grade;
            classEntity.Code = code;

            var itemId = this._classDomainRepository.CreateClass(classEntity);
            AddUserInClass(request.UserId, code);

            response.Id = itemId;
            response.ClassName = classEntity.ClassName;
            response.Grade = classEntity.Grade;
            response.Code = code;  

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
            response.ClassName = classEntity.ClassName;
            response.Grade = classEntity.Grade;
            response.Code = classEntity.Code;

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
                response.ClassName = item.ClassName;
                response.Grade = item.Grade;
                response.Code = item.Code;


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

            classEntity.ClassName = request.ClassName;
            classEntity.Grade = request.Grade;
            this._classDomainRepository.Update(classEntity);


            GetClassResponse response = new GetClassResponse();
            response.Id = classEntity.Id;
            response.ClassName = classEntity.ClassName;
            response.Grade = classEntity.Grade;

            return response;
        }

        public GetClassResponse GetClassByCode(string code) {
            var classEntity = this._classDomainRepository.GetClassByCode(code);
            if (classEntity == null)
            {
                throw new Exception("Class not found!");
            }
            GetClassResponse response = new GetClassResponse();

            response.Id = classEntity.Id;
            response.ClassName = classEntity.ClassName;
            response.Grade = classEntity.Grade;
            response.Code = classEntity.Code;

            return response;
        }


        private static string GenerateClassCode()
        {
            var _random = new Random();
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int codeLength = _random.Next(1, 5);
            var codeBuilder = new StringBuilder(codeLength);

            for (int i = 0; i < codeLength; i++)
            {
                int randomIndex = _random.Next(0, allowedChars.Length);
                char randomChar = allowedChars[randomIndex];
                codeBuilder.Append(randomChar);
            }

            return codeBuilder.ToString();
        }
    }

    
}
