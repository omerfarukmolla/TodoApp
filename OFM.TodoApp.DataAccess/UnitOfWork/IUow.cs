using OFM.TodoApp.DataAccess.Interfaces;
using OFM.TodoApp.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFM.TodoApp.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        Task SaveChange();
    }
}
