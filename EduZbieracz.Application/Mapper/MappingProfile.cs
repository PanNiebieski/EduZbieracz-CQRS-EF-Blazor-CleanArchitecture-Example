using AutoMapper;
using EduZbieracz.Application.Functions.Categories.Commands.CreateCategory;
using EduZbieracz.Application.Functions.Categories.Queries.GetCategoryList;
using EduZbieracz.Application.Functions.Categories.Queries.GetCategoryListWithPosts;
using EduZbieracz.Application.Functions.Posts;
using EduZbieracz.Application.Functions.Posts.Commands.CreatePost;
using EduZbieracz.Application.Functions.Posts.Commands.UpdatePost;
using EduZbieracz.Application.Functions.Webinars.Command;
using EduZbieracz.Application.Functions.Webinars.Queries.GetWebinarListByDate;
using EduZbieracz.Domain.Entities;

namespace EduZbieracz.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostInListViewModel>()
                .ReverseMap();
            CreateMap<Post, PostDetailViewModel>()
                .ReverseMap();
            CreateMap<Category, CategoryDto>();

            CreateMap<Category, CategoryInListViewModel>();
            CreateMap<Category, CategoryPostDto>();
            CreateMap<Category, CategoryPostListViewModel>();

            CreateMap<Post, CreatedPostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();

            CreateMap<Category, CreatedCategoryCommand>().ReverseMap();

            CreateMap<Webinar, WebinarsByDateViewModel>().ReverseMap();
            CreateMap<Webinar, CreatedWebinarCommand>();
        }
    }
}
