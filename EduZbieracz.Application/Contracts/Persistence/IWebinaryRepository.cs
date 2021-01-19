using EduZbieracz.Application.Common;
using EduZbieracz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Contracts.Persistence
{
    public interface IWebinaryRepository : IAsyncRepository<Webinar>
    {
        Task<int> GetTotalCountOfWebinarsForDate(SearchOptionsWebinars options, DateTime? date);
        Task<List<Webinar>> GetPagedWebinarsForDate(SearchOptionsWebinars options, int page, int pageSize, DateTime? date);
    }
}
