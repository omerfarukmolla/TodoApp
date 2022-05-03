using FluentValidation;
using OFM.TodoApp.Dtos.WorkDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFM.TodoApp.Business.ValidationRules
{
    public class WorkUpdateDtoValidator : AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Is Tanımı Boş Gecilemez");
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
