using AutoMapper;
using EdoZbieracz.UI.Services;
using EdoZbieracz.UI.ViewModels;

namespace EduZbieracz.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostInListViewModel, PostBlazorViewModel>().ReverseMap();
            CreateMap<PostDetailViewModel, PostDetailBlazorViewModel>().ReverseMap();

            CreateMap<PostDetailBlazorViewModel, CreatedPostCommand>().ReverseMap();
            CreateMap<PostDetailBlazorViewModel, UpdatePostCommand>().ReverseMap();

            CreateMap<CategoryPostDto, PostInsideCategoryBlazorViewModel>().ReverseMap();

            CreateMap<CategoryDto, CategoryBlazorViewModel>().ReverseMap();

            CreateMap<CategoryInListViewModel, CategoryBlazorViewModel>().ReverseMap();

            CreateMap<CategoryPostListViewModel, CategoryWithPostsBlazorViewModel>().ReverseMap();
            CreateMap<CreatedCategoryCommand, CategoryBlazorViewModel>().ReverseMap();

            CreateMap<WebinarsByDateViewModel, WebinarForDateListBlazorViewModel>().ReverseMap();
            CreateMap<PageWebinarByDateViewModel, WebinarPagedForDateBlazorViewModel>().ReverseMap();

        }
    }
}
