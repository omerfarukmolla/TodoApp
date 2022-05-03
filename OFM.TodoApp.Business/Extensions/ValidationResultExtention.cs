using FluentValidation.Results;
using OFM.TodoApp.Common.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFM.TodoApp.Business.Extensions
{
    public static class ValidationResultExtention
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();
            foreach (var validation in validationResult.Errors)
            {

                errors.Add(new()
                {
                    ErrorMessage = validation.ErrorMessage,
                    PropertyName = validation.PropertyName
                });
            }
            return errors;
        }
    }
}
