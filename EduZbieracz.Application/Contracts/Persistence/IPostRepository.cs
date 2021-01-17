using EduZbieracz.Domain.Entities;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Contracts.Persistence
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
        Task<bool> IsNameAndAuthorAlreadyExist(string title, string author);
    }
}
