using AutoMapper;
using EduZbieracz.Application.Contracts.Persistence;
using EduZbieracz.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Functions.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var posttodelete = await _postRepository.GetByIdAsync(request.PostId);

            await _postRepository.DeleteAsync(posttodelete);

            return Unit.Value;
        }

        public DeletePostCommandHandler(IPostRepository postRepository,
    IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
    }
}
