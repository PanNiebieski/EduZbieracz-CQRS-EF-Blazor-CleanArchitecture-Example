using EduZbieracz.Application.Common;
using EduZbieracz.Application.Functions.Webinars.Command;
using EduZbieracz.Application.Functions.Webinars.Command.DeleteWebinar;
using EduZbieracz.Application.Functions.Webinars.Command.UpdateWebinar;
using EduZbieracz.Application.Functions.Webinars.Queries.GetWebinar;
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

        [HttpGet("/getwebinarfordate", Name = "GetPagedWebinarsForDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PageWebinarByDateViewModel>> GetPagedOrdersForMonth(SearchOptionsWebinars searchOptionsWebinars, int page, int pagesize, DateTime? date)
        {
            var getWebinarForMonthQuery = new GetWebinarsByDateQuery()
            { Date = date, Page = page, PageSize = pagesize, Options = searchOptionsWebinars };
            var pageWebinarsByDateViewModel = await _mediator.Send(getWebinarForMonthQuery);

            return Ok(pageWebinarsByDateViewModel);
        }


        [HttpPost(Name = "AddWebinar")]
        public async Task<ActionResult<int>> Create([FromBody] CreatedWebinarCommand createWebinarCommand)
        {
            var result = await _mediator.Send(createWebinarCommand);
            return Ok(result.Id);
        }

        [HttpGet("{id}", Name = "GetWebinar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<WebinarViewModel>> GetWebinarById(int id)
        {
            var result = await _mediator.Send((new GetWebinarQuery() { Id = id }));
            return Ok(result);
        }

        [HttpPut(Name = "UpdateWebinar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateWebinarCommand updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);


            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteWebinar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deletepostCommand = new DeleteWebinarCommand() { WebinarId = id };
            await _mediator.Send(deletepostCommand);
            return NoContent();
        }
    }
}
