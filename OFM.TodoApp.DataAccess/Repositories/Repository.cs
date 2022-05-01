using Microsoft.EntityFrameworkCore;
using OFM.TodoApp.DataAccess.Context;
using OFM.TodoApp.DataAccess.Interfaces;
using OFM.TodoApp.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OFM.TodoApp.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TodoContext _context;

        public Repository(TodoContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _context.Set<T>().SingleOrDefaultAsync(filter) : await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetById(object Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(object id)
        {
            var deletedEntity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(deletedEntity);
            //_context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            var updatedEntity = _context.Set<T>().Find(entity.Id);
            _context.Entry(updatedEntity).CurrentValues.SetValues(entity);
            //_context.Set<T>().Update(entity);
        }
    }
}
