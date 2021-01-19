using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Functions.Webinars.Queries.GetWebinar
{
    public class GetWebinarQuery : IRequest<WebinarViewModel>
    {
        public int Id { get; set; }
    }
}
