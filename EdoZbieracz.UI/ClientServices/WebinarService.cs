using AutoMapper;
using EdoZbieracz.UI.Services;
using EdoZbieracz.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.ClientServices
{
    public class WebinarService : IWebinarService
    {
        private readonly IMapper _mapper;
        private IClient _client;

        public WebinarService(IClient client, IMapper mapper)
        {
            _mapper = mapper;
            _client = client;
        }

        public async Task<ResponseFromApi<int>> CreateWebinar(WebinarBlazorVM webinar)
        {
            try
            {
                CreatedWebinarCommand createWebinarCommand =
                    _mapper.Map<CreatedWebinarCommand>(webinar);

                var newId = await _client.AddWebinarAsync(createWebinarCommand);
                return new ResponseFromApi<int>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ex.ConvertApiExceptions();
            }
        }



        public async Task<WebinarPagedForDateBlazorVM> GetPagedWebinarForDate(SearchOptionsWebinars s, DateTime? date, int page, int pageSize)
        {
            var webinars = await _client.GetPagedWebinarsForDateAsync(s, page, pageSize, date);
            var mappedOrders = _mapper.Map<WebinarPagedForDateBlazorVM>(webinars);
            return mappedOrders;
        }

        public async Task<WebinarBlazorVM> GetWebinarById(int id)
        {
            var selectedWebinar = await _client.GetWebinarAsync(id);
            var mappedWebinar = _mapper.Map<WebinarBlazorVM>(selectedWebinar);
            return mappedWebinar;
        }

        public async Task<ResponseFromApi<int>> UpdateWebinar(WebinarBlazorVM webinarDetailViewModel)
        {
            try
            {
                UpdateWebinarCommand updateWebinarCommand = _mapper.Map<UpdateWebinarCommand>(webinarDetailViewModel);
                await _client.UpdateWebinarAsync(updateWebinarCommand);
                return new ResponseFromApi<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ex.ConvertApiExceptions();
            }
        }

        public async Task<ResponseFromApi<int>> DeleteWebinar(int id)
        {
            try
            {
                await _client.DeleteWebinarAsync(id);
                return new ResponseFromApi<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ex.ConvertApiExceptions();
            }
        }
    }
}
