using AutoMapper;
using OFM.TodoApp.Dtos.WorkDtos;
using OFM.TodoApp.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFM.TodoApp.Business.Mapping.AuotMapperWork
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkListDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDto>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();
        }
    }
}
