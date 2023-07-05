using Domain.Entities;
using Domain.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IMClassUserDomainRepository : IGenericDataRepository<MClassUserEntity>
    {
        void CreateMCU(MClassUserEntity entity);
        void DeleteClassByClassId(int classId);
        void DeleteUserByUserId(int userId);
        List<MClassUserEntity> GetClassesByUserId(int userId);
        List<MClassUserEntity> GetUsersByClassId(int classId);
        List<MClassUserEntity> GetAllMCU();
        bool UserExistInClass(int userId);
    }
}
