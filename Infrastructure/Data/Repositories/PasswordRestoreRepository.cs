using Domain.Entities;
using Domain.Interfaces.Generics;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class PasswordRestoreRepository : GenericDataDbRepository<PasswordRestoreEntity>, IPasswordRestoreDomainRepository
    {

        public PasswordRestoreRepository(AppDbContext contex) : base(contex)
        {
            Context = contex;
        }

        public async Task<int> CreateCodeAsync(PasswordRestoreEntity entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                var id =  await this.AddAsync(entity);
                return id;
            }
            catch(Exception e) {
                throw e;
            }
            
        }

        public bool DeleteCodeById(int Id)
        {
            var codeEntity = this.GetCodeByUserId(Id);
            if (codeEntity != null)
            {
                this.RemoveSync(codeEntity);
                return true;
            }
            return false;
        }

        public PasswordRestoreEntity GetCodeByUserId(int userId)
        {
            var codeEntity = this.Context.PasswordRestoreEntity.Where(x => x.UserId == userId).FirstOrDefault();
            return codeEntity;
        }

        public void DeleteAllUserCodes(int userId) {
            
            var codes = this.Context.PasswordRestoreEntity.Where(x => x.UserId == userId).ToList();
            this.Context.PasswordRestoreEntity.RemoveRange(codes);
            this.Context.SaveChanges();

        }
    }
}
