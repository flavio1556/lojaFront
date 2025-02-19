using Lojaback.Domain.Filter;
using Lojaback.Domain.Interfaces.Entities;
using Lojaback.Domain.Interfaces.Repository;
using LojaBack.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LojaBack.Infra.Data.RepositoryService
{
    public class Repository<T> : IRepository<T> where T : class, IModel
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Remove(entity);
            await SaveContextAsync();

        }
        public async Task<IEnumerable<T>> GetByFilterAsync(Filter<T> filter)
        {
            IQueryable<T> query = _dbSet;

            // Adiciona filtros dinamicamente
            foreach (var kvp in filter.Filters)
            {
                var propertyName = kvp.Key;
                var propertyValue = kvp.Value;

                // Cria uma expressão para cada filtro
                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.Property(parameter, propertyName);
                var constant = Expression.Constant(propertyValue);
                var equalExpression = Expression.Equal(property, constant);
                var lambda = Expression.Lambda<Func<T, bool>>(equalExpression, parameter);

                // Aplica o filtro à consulta
                query = query.Where(lambda);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            if (id == 0)
                throw new ArgumentException("ID não pode ser 0.", nameof(id));

            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _dbSet.Update(entity);
            await SaveContextAsync();
            return entity;
        }
        private async Task SaveContextAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
