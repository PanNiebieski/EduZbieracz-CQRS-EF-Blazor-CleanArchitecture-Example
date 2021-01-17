using EduZbieracz.Application.Contracts.Persistence;
using EduZbieracz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduZbieracz.Persistence.EF.Repositories
{
    public class WebinaryRepository : BaseRepository<Webinar>, IWebinaryRepository
    {
        public WebinaryRepository(EduZbieraczContext dbContext) : base(dbContext)
        { }

        public async Task<List<Webinar>> GetPagedWebinarsForDate(DateTime date, int page, int pageSize)
        {
            return await _dbContext.Webinars.Where(x => x.Date.Month == date.Month && x.Date.Year == date.Year)
                .Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTotalCountOfWebinarsForDate(DateTime date)
        {
            return await _dbContext.Webinars.CountAsync
                (x => x.Date.Month == date.Month && x.Date.Year == date.Year);
        }
    }
}
