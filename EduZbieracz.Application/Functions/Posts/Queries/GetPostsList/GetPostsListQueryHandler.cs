using AutoMapper;
using EduZbieracz.Application.Contracts.Persistence;
using EduZbieracz.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Functions.Posts
{
    public class GetPostsListQueryHandler :
        IRequestHandler<GetPostsListQuery, List<PostInListViewModel>>
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public GetPostsListQueryHandler
            (IMapper mapper,
            IAsyncRepository<Post> postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<List<PostInListViewModel>>
            Handle(GetPostsListQuery request,
            CancellationToken cancellationToken)
        {
            var all = await _postRepository.GetAllAsync();
            var allordered = all.OrderBy(x => x.Date);

            return _mapper.Map<List<PostInListViewModel>>(all);
        }
    }
}
