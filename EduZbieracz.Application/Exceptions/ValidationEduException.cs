using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduZbieracz.Application.Exceptions
{
    public class ValidationEduException : ApplicationException
    {
        public List<string> ErrorMessages { get; set; }

        public ValidationEduException(ValidationResult validationResult)
        {
            ErrorMessages = new List<String>();

            foreach (var item in validationResult.Errors)
            {
                ErrorMessages.Add(item.ErrorMessage);
            }
        }
    }
}
