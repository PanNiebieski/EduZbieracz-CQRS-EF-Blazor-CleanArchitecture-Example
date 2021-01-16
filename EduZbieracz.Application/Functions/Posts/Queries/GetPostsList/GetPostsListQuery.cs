using MediatR;
using System.Collections.Generic;

namespace EduZbieracz.Application.Functions.Posts
{
    public class GetPostsListQuery : IRequest<List<PostInListViewModel>>
    {
    }
}
