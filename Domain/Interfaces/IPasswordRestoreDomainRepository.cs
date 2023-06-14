using Domain.Entities;
using Domain.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IPasswordRestoreDomainRepository : IGenericDataRepository<PasswordRestoreEntity>
    {
        Task<int> CreateCodeAsync(PasswordRestoreEntity entity);
        PasswordRestoreEntity GetCodeByUserId(int userId);
        bool DeleteCodeById(int Id);
        void DeleteAllUserCodes(int userId);
    }
}
