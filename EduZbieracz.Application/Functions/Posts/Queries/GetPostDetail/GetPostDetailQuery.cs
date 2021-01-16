using MediatR;

namespace EduZbieracz.Application.Functions.Posts
{
    public class GetPostDetailQuery : IRequest<PostDetailViewModel>
    {
        public int Id { get; set; }
    }
}
