using Lojaback.Domain.Filter;
using Lojaback.Domain.Interfaces.Entities;
using Lojaback.Domain.Interfaces.Repository;
using Lojaback.Domain.Interfaces.SaveHandlers;
using Lojaback.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LojaBack.Application.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class, IModel
    {
        private readonly IRepository<T> _repository;
        private readonly ISaveHandler<T> _saveHandler;
        public ServiceBase(IRepository<T> repository, ISaveHandler<T> saveHandler)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _saveHandler = saveHandler ?? throw new ArgumentNullException(nameof(saveHandler));
        }

        public async Task<T> AddAsync(T entity)
        {
            await _saveHandler.ValidateAsync(entity);
            return await _repository.AddAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await _saveHandler.ValidateAsync(entity);
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false; 
            }

            await _repository.DeleteAsync(entity);
            return true;
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Filter<T> filter = null)
        {
            if(filter == null)
            {
                return await _repository.GetAllAsync();
            }
            else
            {
                return await _repository.GetByFilterAsync(filter);
            }
                
        }
    }
}
