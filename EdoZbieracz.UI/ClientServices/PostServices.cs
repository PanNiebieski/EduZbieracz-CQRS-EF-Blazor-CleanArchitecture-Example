using AutoMapper;
using EdoZbieracz.UI.Services;
using EdoZbieracz.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.ClientServices
{
    public class PostServices : IPostServices
    {
        private readonly IMapper _mapper;
        private IClient _client;

        public PostServices(IClient client, IMapper mapper)
        {
            _mapper = mapper;
            _client = client;
        }



        public async Task<ResponseFromApi<int>> CreatePost(PostDetailBlazorVM postDetailViewModel)
        {
            try
            {
                CreatedPostCommand createPostCommand =
                    _mapper.Map<CreatedPostCommand>(postDetailViewModel);

                var newId = await _client.AddPostAsync(createPostCommand);
                return new ResponseFromApi<int>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ex.ConvertApiExceptions();
            }
        }

        public async Task<ResponseFromApi<int>> DeletePost(int id)
        {
            try
            {
                await _client.DeletePostAsync(id);
                return new ResponseFromApi<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ex.ConvertApiExceptions();
            }
        }

        public async Task<List<PostInListBlazorVM>> GetAllPosts()
        {
            var allPosts = await _client.GetAllPostsAsync();
            var mappedPosts = _mapper.Map<ICollection<PostInListBlazorVM>>(allPosts);
            return mappedPosts.ToList();
        }

        public async Task<PostDetailBlazorVM> GetPostById(int id)
        {
            var selectedPost = await _client.GetPostByIdAsync(id);
            var mappedPost = _mapper.Map<PostDetailBlazorVM>(selectedPost);
            return mappedPost;
        }

        public async Task<ResponseFromApi<int>> UpdatePost(PostDetailBlazorVM postDetailViewModel)
        {
            try
            {
                UpdatePostCommand updatePostCommand = _mapper.Map<UpdatePostCommand>(postDetailViewModel);
                await _client.UpdatePostAsync(updatePostCommand);
                return new ResponseFromApi<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ex.ConvertApiExceptions();
            }
        }
    }
}
