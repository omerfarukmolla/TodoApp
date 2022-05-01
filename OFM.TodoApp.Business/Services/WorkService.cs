using AutoMapper;
using OFM.TodoApp.Business.Interfaces;
using OFM.TodoApp.DataAccess.UnitOfWork;
using OFM.TodoApp.Dtos.Interfaces;
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
        private readonly IMapper _mapper;
        public WorkService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Create(WorkCreateDto dto)
        {
            await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto)); ;

            await _uow.SaveChange();
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            return _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
        }

        public async Task<IDto> GetById<IDto>(int id)
        {
            return _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
        }

        public async Task Remove(int id)
        {

            _uow.GetRepository<Work>().Remove(id);
            await _uow.SaveChange();

        }

        public async Task Update(WorkUpdateDto dto)
        {
            _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto));

            await _uow.SaveChange();
        }
    }
}
