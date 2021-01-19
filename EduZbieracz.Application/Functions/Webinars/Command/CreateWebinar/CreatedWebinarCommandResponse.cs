using EduZbieracz.Application.Responses;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Functions.Webinars.Command
{
    public class CreatedWebinarCommandResponse : BaseResponse
    {
        public int? Id { get; set; }

        public CreatedWebinarCommandResponse() : base()
        { }

        public CreatedWebinarCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public CreatedWebinarCommandResponse(string message)
        : base(message)
        { }

        public CreatedWebinarCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public CreatedWebinarCommandResponse(int webinarId)
        {
            Id = webinarId;
        }
    }
}
