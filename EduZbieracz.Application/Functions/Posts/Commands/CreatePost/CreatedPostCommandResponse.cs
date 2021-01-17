using EduZbieracz.Application.Responses;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatedPostCommandResponse : BaseResponse
    {
        public int? PostId { get; set; }

        public CreatedPostCommandResponse() : base()
        { }

        public CreatedPostCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public CreatedPostCommandResponse(string message)
        : base(message)
        { }

        public CreatedPostCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public CreatedPostCommandResponse(int postId)
        {
            PostId = postId;
        }
    }
}
