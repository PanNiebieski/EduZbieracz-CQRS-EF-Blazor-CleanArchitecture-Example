using AutoMapper;
using EduZbieracz.Application.Contracts.Persistence;
using EduZbieracz.Application.Exceptions;
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
        : IRequestHandler<CreatedPostCommand, int>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public async Task<int> Handle(CreatedPostCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreatedPostCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                throw new ValidationEduException(validatorResult);

            var post = _mapper.Map<Post>(request);

            post = await _postRepository.AddAsync(post);

            return post.PostId;
        }

        public CreatedPostCommandHandler(IPostRepository postRepository,
            IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
    }
}
