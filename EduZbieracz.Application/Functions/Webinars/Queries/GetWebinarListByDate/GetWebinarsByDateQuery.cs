using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Functions.Webinars.Queries.GetWebinarListByDate
{
    public class GetWebinarsByDateQuery : IRequest<PageWebinarByDateViewModel>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
