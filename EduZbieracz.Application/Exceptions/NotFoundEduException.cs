using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Exceptions
{
    public class NotFoundEduException : ApplicationException
    {
        public NotFoundEduException(string name, object key)
        : base($"{name} ({key}) is not found")
        {

        }
    }
}
