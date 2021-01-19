using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Functions.Webinars.Command.DeleteWebinar
{
    public class DeleteWebinarCommand : IRequest
    {
        public int WebinarId { get; set; }
    }
}
