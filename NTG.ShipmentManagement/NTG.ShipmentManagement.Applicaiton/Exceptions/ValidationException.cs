using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace NTG.ShipmentManagement.Applicaiton.Exceptions
{
    public class ValidationException: ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();
        public ValidationException(ValidationResult validationResult)
        {
            Errors = validationResult.Errors.Select(v => v.ErrorMessage).ToList();
        }

        public ValidationException(List<string> errors)
        {
            Errors.AddRange(errors);
        }
    }
}