using Lojaback.Domain.Filter;
using Lojaback.Domain.Interfaces.Entities;
using Lojaback.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojaback.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class, IModel
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(long id);
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetAllAsync(Filter<T> filter = null);

    }
}
