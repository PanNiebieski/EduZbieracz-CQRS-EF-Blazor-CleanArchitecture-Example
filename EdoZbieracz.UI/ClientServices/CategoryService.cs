using AutoMapper;
using Blazored.LocalStorage;
using EdoZbieracz.UI.Services;
using EdoZbieracz.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdoZbieracz.UI.ClientServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;

        public CategoryService(IClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<ResponseFromApi<int>> CreateCategory(CategoryBlazorViewModel categoryViewModel)
        {
            try
            {
                ResponseFromApi<int> apiResponse = new ResponseFromApi<int>();
                CreatedCategoryCommand createCategoryCommand = _mapper.Map<CreatedCategoryCommand>(categoryViewModel);
                var createCategoryCommandResponse = await _client.AddCategoryAsync(createCategoryCommand);
                if (createCategoryCommandResponse.Success)
                {
                    apiResponse.Data = createCategoryCommandResponse.CategoryId.Value;
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = -1;
                    foreach (var error in createCategoryCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ex.ConvertApiExceptions();
            }
        }

        public async Task<List<CategoryBlazorViewModel>> GetAllCategories()
        {
            var allCategories = await _client.GetAllCategoriesAsync();
            var mappedCategories = _mapper.Map<ICollection<CategoryBlazorViewModel>>(allCategories);
            return mappedCategories.ToList();
        }

        public async Task<List<CategoryWithPostsBlazorViewModel>> GetAllCategoriesWithPosts(SearchCategoryOptions searchCategoryOptions)
        {
            var allCategories = await _client.GetCategoriesWithPostsAsync(searchCategoryOptions);
            var mappedCategories = _mapper.Map<ICollection<CategoryWithPostsBlazorViewModel>>(allCategories);
            return mappedCategories.ToList();
        }


    }
}
