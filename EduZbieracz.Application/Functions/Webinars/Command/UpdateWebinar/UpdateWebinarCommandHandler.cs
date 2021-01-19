using AutoMapper;
using EduZbieracz.Application.Contracts.Persistence;
using EduZbieracz.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Functions.Webinars.Command.UpdateWebinar
{
    public class UpdateWebinarCommandHandler : IRequestHandler<UpdateWebinarCommand>
    {
        private readonly IWebinaryRepository _webinarRepository;
        private readonly IMapper _mapper;

        public async Task<Unit> Handle(UpdateWebinarCommand request,
            CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Webinar>(request);

            await _webinarRepository.UpdateAsync(post);

            return Unit.Value;
        }

        public UpdateWebinarCommandHandler(IWebinaryRepository webinarRepository,
            IMapper mapper)
        {
            _webinarRepository = webinarRepository;
            _mapper = mapper;
        }
    }
}

