using AutoMapper;
using EduZbieracz.Application.Contracts.Persistence;
using EduZbieracz.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Functions.Webinars.Command
{
    public class CreatedWebinarCommandHandler
        : IRequestHandler<CreatedWebinarCommand, CreatedWebinarCommandResponse>
    {
        public async Task<CreatedWebinarCommandResponse>
            Handle(CreatedWebinarCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreatedWebinarCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreatedWebinarCommandResponse(validatorResult);

            var webinar = _mapper.Map<Webinar>(request);

            webinar = await _webinaryRepository.AddAsync(webinar);

            return new CreatedWebinarCommandResponse(webinar.Id);
        }

        public CreatedWebinarCommandHandler(IWebinaryRepository webinaryRepository,
            IMapper mapper)
        {
            _webinaryRepository = webinaryRepository;
            _mapper = mapper;
        }

        private readonly IWebinaryRepository _webinaryRepository;
        private readonly IMapper _mapper;
    }
}
