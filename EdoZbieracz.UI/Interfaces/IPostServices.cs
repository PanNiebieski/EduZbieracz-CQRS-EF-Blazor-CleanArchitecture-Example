using EdoZbieracz.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.ClientServices
{
    public interface IPostServices
    {

        Task<List<PostInListBlazorVM>> GetAllPosts();
        Task<PostDetailBlazorVM> GetPostById(int id);
        Task<ResponseFromApi<int>> CreatePost(PostDetailBlazorVM postDetailViewModel);
        Task<ResponseFromApi<int>> UpdatePost(PostDetailBlazorVM postDetailViewModel);
        Task<ResponseFromApi<int>> DeletePost(int id);

    }
}
