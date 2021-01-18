using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Functions.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public int PostId { get; set; }
    }
}
