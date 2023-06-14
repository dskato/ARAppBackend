using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IGenericDataRepository<T> where T : class
    {
        Task<int> AddAsync(params T[] items);
        int AddSync(params T[] items);
        Task<int> Update(params T[] items);
        int RemoveSync(params T[] items);
        Task<IList<T>> GetAll(params Expression<Func<T, object>>[] navigationProperties);
  

    }
}
