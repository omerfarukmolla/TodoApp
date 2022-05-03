using FluentValidation;
using OFM.TodoApp.Dtos.WorkDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFM.TodoApp.Business.ValidationRules
{
    public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Iş Tanımı Boş Gecilemez");
        }

    }
}
