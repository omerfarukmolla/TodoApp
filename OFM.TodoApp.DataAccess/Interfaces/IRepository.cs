using OFM.TodoApp.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OFM.TodoApp.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(object Id);
        Task<T> GetByFilter(Expression<Func<T,bool>> filter, bool asNoTracking = false);
        Task Create(T entity);
        void Update(T entity);
        void Remove(object id);
        IQueryable<T> GetQuery();
    }
}
