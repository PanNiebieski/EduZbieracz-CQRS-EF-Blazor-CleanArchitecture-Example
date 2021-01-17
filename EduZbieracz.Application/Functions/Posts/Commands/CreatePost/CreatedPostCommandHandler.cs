using AutoMapper;
using EduZbieracz.Application.Contracts.Persistence;
using EduZbieracz.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatedPostCommandHandler
        : IRequestHandler<CreatedPostCommand, CreatedPostCommandResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public async Task<CreatedPostCommandResponse>
            Handle(CreatedPostCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreatedPostCommandValidator(_postRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreatedPostCommandResponse(validatorResult);

            var post = _mapper.Map<Post>(request);

            post = await _postRepository.AddAsync(post);

            return new CreatedPostCommandResponse(post.PostId);
        }

        public CreatedPostCommandHandler(IPostRepository postRepository,
            IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
    }
}
