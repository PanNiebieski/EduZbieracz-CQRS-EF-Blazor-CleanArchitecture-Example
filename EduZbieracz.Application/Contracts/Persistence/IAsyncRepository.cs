using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

    }

    //public class GetVideoCoursesListQuery
    //    : IRequest<List<VideoCoursesVideModel>>
    //{ }

    //public class GetVideoCoursesQueryHandler
    //    : IRequestHandler<GetVideoCoursesListQuery, List<VideoCoursesVideModel>>
    //{
    //    public async Task<List<VideoCoursesVideModel>> Handle
    //        (GetVideoCoursesListQuery request, CancellationToken cancellationToken)
    //    {

    //    }
    //}
}
