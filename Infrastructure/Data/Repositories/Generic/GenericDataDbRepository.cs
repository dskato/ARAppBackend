using Domain.Interfaces.Generics;
using Domain.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories.Generic
{
    public abstract class GenericDataDbRepository<T> : IGenericDataRepository<T> where T : class
    {
        public AppDbContext Context { get; set; }
        //private readonly IConfiguration _configuration;

        public GenericDataDbRepository(AppDbContext contex)
        {
            Context = contex;
        }
        public int AddSync(params T[] items)
        {
            foreach (T item in items)
            {
                Context.Entry(item).State = EntityState.Added;
            }
            var result = Context.SaveChanges();
            return result;
        }

        public async Task<int> AddAsync(params T[] items)
        {
            foreach (T item in items)
            {
                Context.Entry(item).State = EntityState.Added;
            }
            var result = await Context.SaveChangesAsync();
            return result;
        }

        public virtual async Task<IList<T>> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = Context.Set<T>();
            foreach (var navigation in navigationProperties)
            {
                dbQuery = dbQuery.Include(navigation);
            }
            var result = await dbQuery.ToArrayAsync();
            return result;
        }

        public int RemoveSync(params T[] items)
        {
            foreach (var item in items)
            {
                Context.Entry(item).State = EntityState.Deleted;
            }
            var result = Context.SaveChanges();
            return result;
        }

        public virtual async Task<int> Update(params T[] items)
        {

            foreach (var item in items)
            {
                Context.Entry(item).State = EntityState.Modified;
            }
            var result = await Context.SaveChangesAsync();
            return result;

        }

    }
}
