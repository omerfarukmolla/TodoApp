using OFM.TodoApp.Business.Interfaces;
using OFM.TodoApp.DataAccess.UnitOfWork;
using OFM.TodoApp.Dtos.WorkDtos;
using OFM.TodoApp.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFM.TodoApp.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;

        public WorkService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _uow.GetRepository<Work>().GetAll();

            var workList = new List<WorkListDto>();

            if (list != null && list.Count() > 0)
            {
                foreach (var work in list)
                {
                    workList.Add(new() 
                    {
                        Definition = work.Definition,
                        IsCompleted = work.IsCompleted,
                        Id=work.Id,
                    });
                }
            }
            return workList;
        }
    }
}
