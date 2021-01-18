using EduZbieracz.Application.Functions.Webinars.Command;
using EduZbieracz.Application.Functions.Webinars.Queries.GetWebinarListByDate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduZbieracz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebinarController : Controller
    {
        private readonly IMediator _mediator;

        public WebinarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/getpagedordersformonth", Name = "GetPagedOrdersForMonth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PageWebinarByDateViewModel>> GetPagedOrdersForMonth(DateTime date, int page, int pagesize)
        {
            var getWebinarForMonthQuery = new GetWebinarsByDateQuery()
            { Date = date, Page = page, PageSize = pagesize };
            var pageWebinarsByDateViewModel = await _mediator.Send(getWebinarForMonthQuery);

            return Ok(pageWebinarsByDateViewModel);
        }


        [HttpPost(Name = "AddWebinar")]
        public async Task<ActionResult<int>> Create([FromBody] CreatedWebinarCommand createWebinarCommand)
        {
            var result = await _mediator.Send(createWebinarCommand);
            return Ok(result.Id);
        }
    }
}
