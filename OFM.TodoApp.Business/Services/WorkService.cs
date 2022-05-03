using AutoMapper;
using FluentValidation;
using OFM.TodoApp.Business.Extensions;
using OFM.TodoApp.Business.Interfaces;
using OFM.TodoApp.Business.ValidationRules;
using OFM.TodoApp.Common.ResponseObjects;
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
        private readonly IValidator<WorkCreateDto> _createValidator;
        private readonly IValidator<WorkUpdateDto> _updateValidator;
        public WorkService(IUow uow, IMapper mapper, IValidator<WorkUpdateDto> updateValidator, IValidator<WorkCreateDto> createValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }

        public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
        {
            var validationResult = _createValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _uow.SaveChange();
                return new Response<WorkCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                return new Response<WorkCreateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidationError());
            }
        }

        public async Task<IResponse<List<WorkListDto>>> GetAll()
        {
            var data = _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
            return new Response<List<WorkListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, "Bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);


        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _uow.GetRepository<Work>().Remove(removedEntity);
                await _uow.SaveChange();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, "Bulunamdı");

        }

        public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
        {
            var validationResult = _updateValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var unchangedEntity = await _uow.GetRepository<Work>().Find(dto.Id);
                if (unchangedEntity != null)
                {
                    _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto), unchangedEntity);
                    await _uow.SaveChange();
                    return new Response<WorkUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<WorkUpdateDto>(ResponseType.NotFound, "Bulunamdı");
            }
            else
            {
                return new Response<WorkUpdateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidationError());
            }
        }
    }
}
