using Lojaback.Domain.Filter;
using Lojaback.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojaback.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : class, IModel
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetByFilterAsync(Filter<T> filter);

    }
}
