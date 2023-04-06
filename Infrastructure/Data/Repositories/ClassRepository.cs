using Domain.Entities;
using Domain.Interfaces.Generics;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Generic;

namespace Infrastructure.Data.Repositories
{
    public class ClassRepository : GenericDataDbRepository<ClassEntity>, IClassDomainRepository
    {
        public ClassRepository(AppDbContext contex) : base(contex)
        {
            Context = contex;
        }



        public int CreateClass(ClassEntity entity)
        {
            this.AddSync(entity);
            return entity.Id;
        }

        public void DeleteClass(int id)
        {
            var entity = this.GetClassById(id);
            if (entity != null)
            {
                this.RemoveSync(entity);
            }
        }


        public List<ClassEntity> GetAllClasses()
        {
            var classLs = this.Context.ClassEntity.ToList();
            return classLs;
        }

        public ClassEntity GetClassById(int id)
        {
            ClassEntity entity = this.Context.ClassEntity.Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }


        public void UpdateClass(ClassEntity clss)
        {
            throw new NotImplementedException();
        }
    }
}
