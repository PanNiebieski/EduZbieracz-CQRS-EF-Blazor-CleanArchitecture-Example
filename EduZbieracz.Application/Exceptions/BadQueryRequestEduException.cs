using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Exceptions
{
    public class BadQueryRequestEduException : ApplicationException
    {
        public BadQueryRequestEduException(string message)
            : base(message)
        {

        }
    }
}
