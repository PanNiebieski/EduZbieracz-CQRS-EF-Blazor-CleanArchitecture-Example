using AutoMapper;
using EdoZbieracz.UI.Services;
using EdoZbieracz.UI.ViewModels;

namespace EduZbieracz.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostInListViewModel, PostInListBlazorVM>().ReverseMap();
            CreateMap<PostDetailViewModel, PostDetailBlazorVM>().ReverseMap();

            CreateMap<PostDetailBlazorVM, CreatedPostCommand>().ReverseMap();
            CreateMap<PostDetailBlazorVM, UpdatePostCommand>().ReverseMap();

            CreateMap<CategoryPostDto, PostInsideCategoryBlazorVM>().ReverseMap();

            CreateMap<CategoryDto, CategoryBlazorVM>().ReverseMap();

            CreateMap<CategoryInListViewModel, CategoryBlazorVM>().ReverseMap();

            CreateMap<CategoryPostListViewModel, CategoryWithPostsBlazorVM>().ReverseMap();
            CreateMap<CreatedCategoryCommand, CategoryBlazorVM>().ReverseMap();

            CreateMap<WebinarsByDateViewModel, WebinarForDateListBlazorVM>().ReverseMap();
            CreateMap<PageWebinarByDateViewModel, WebinarPagedForDateBlazorVM>().ReverseMap();


            CreateMap<CreatedWebinarCommand, WebinarBlazorVM>().ReverseMap();
            CreateMap<UpdateWebinarCommand, WebinarBlazorVM>().ReverseMap();

        }
    }
}
