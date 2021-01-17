using EduZbieracz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Contracts.Persistence
{
    public interface IWebinaryRepository : IAsyncRepository<Webinar>
    {
        Task<int> GetTotalCountOfWebinarsForDate(DateTime date);
        Task<List<Webinar>> GetPagedWebinarsForDate(DateTime date, int page, int pageSize);
    }
}
