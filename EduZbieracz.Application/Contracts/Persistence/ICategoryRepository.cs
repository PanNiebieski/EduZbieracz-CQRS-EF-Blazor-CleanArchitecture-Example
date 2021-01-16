using EduZbieracz.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>>
            GetCategoriesWithPost(SearchCategoryOptions searchCategory);
    }
}
