using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IClassDomainRepository : IGenericDataRepository<ClassEntity>
    {
        int CreateClass(ClassEntity entity);
        void DeleteClass(int id);
        void UpdateClass(ClassEntity entity);
        List<ClassEntity> GetAllClasses();
        ClassEntity GetClassById(int id);
    }
}
