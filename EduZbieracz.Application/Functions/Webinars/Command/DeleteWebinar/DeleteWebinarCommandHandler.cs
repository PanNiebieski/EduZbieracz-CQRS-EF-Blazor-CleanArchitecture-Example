using AutoMapper;
using EduZbieracz.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Functions.Webinars.Command.DeleteWebinar
{
    public class DeleteWebinarCommandHandler : IRequestHandler<DeleteWebinarCommand>
    {
        private readonly IWebinaryRepository _webinarRepository;
        private readonly IMapper _mapper;

        public async Task<Unit> Handle(DeleteWebinarCommand request, CancellationToken cancellationToken)
        {
            var posttodelete = await _webinarRepository.GetByIdAsync(request.WebinarId);

            await _webinarRepository.DeleteAsync(posttodelete);

            return Unit.Value;
        }

        public DeleteWebinarCommandHandler(IWebinaryRepository webinarRepository,
    IMapper mapper)
        {
            _webinarRepository = webinarRepository;
            _mapper = mapper;
        }

    }
}
