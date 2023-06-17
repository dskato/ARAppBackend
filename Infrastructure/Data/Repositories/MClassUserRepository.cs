using Domain.Entities;
using Domain.Interfaces.Generics;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Generic;

namespace Infrastructure.Data.Repositories
{
    public class MClassUserRepository : GenericDataDbRepository<MClassUserEntity>, IMClassUserDomainRepository
    {
        public MClassUserRepository(AppDbContext contex) : base(contex)
        {
            Context = contex;
        }

        public void CreateMCU(MClassUserEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            this.AddAsync(entity);
        }

        public void DeleteClassByClassId(int classId)
        {
            var entities = this.GetClassesByUserId(classId);
            if (entities != null && entities.Count() > 0)
            {
                foreach (var entity in entities) {
                  this.RemoveSync(entity);
                }   
            }
        }

        public void DeleteUserByUserId(int userId)
        {
            var entities = this.GetUsersByClassId(userId);
            if (entities != null && entities.Count() > 0)
            {
                foreach (var entity in entities)
                {
                    this.RemoveSync(entity);
                }
            }
        }

        public List<MClassUserEntity> GetUsersByClassId(int classId)
        {
            var entity = this.Context.MClassUserEntity.Where(x => x.ClassId == classId).ToList();
            return entity;
        }

        public List<MClassUserEntity> GetClassesByUserId(int userId)
        {
            var entity = this.Context.MClassUserEntity.Where(x => x.UserId == userId).ToList();
            return entity;
        }
    }
}
