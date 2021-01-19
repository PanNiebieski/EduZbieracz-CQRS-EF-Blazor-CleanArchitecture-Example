using EduZbieracz.Application.Common;
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

        public async Task<List<Webinar>> GetPagedWebinarsForDate(SearchOptionsWebinars options, int page, int pageSize, DateTime? date)
        {
            if (options == SearchOptionsWebinars.MonthAndYear && date.HasValue)
            {
                return await _dbContext.Webinars.Where(x => x.Date.Month == date.Value.Month && x.Date.Year == date.Value.Year)
                    .Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            }
            if (options == SearchOptionsWebinars.Year && date.HasValue)
            {
                return await _dbContext.Webinars.Where(x => x.Date.Year == date.Value.Year)
                    .Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            }
            if (options == SearchOptionsWebinars.Month && date.HasValue)
            {
                return await _dbContext.Webinars.Where(x => x.Date.Month == date.Value.Month)
                    .Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            }


            return await _dbContext.Webinars
                .Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();


        }
        public async Task<int> GetTotalCountOfWebinarsForDate(SearchOptionsWebinars options, DateTime? date)
        {
            if (options == SearchOptionsWebinars.MonthAndYear && date.HasValue)
            {
                return await _dbContext.Webinars.CountAsync
                                (x => x.Date.Month == date.Value.Month && x.Date.Year == date.Value.Year);
            }
            if (options == SearchOptionsWebinars.Year && date.HasValue)
            {
                return await _dbContext.Webinars.CountAsync
                   (x => x.Date.Year == date.Value.Year);
            }
            if (options == SearchOptionsWebinars.Month && date.HasValue)
            {
                return await _dbContext.Webinars.CountAsync
                  (x => x.Date.Year == date.Value.Year);
            }


            return await _dbContext.Webinars.CountAsync();


        }
    }
}

