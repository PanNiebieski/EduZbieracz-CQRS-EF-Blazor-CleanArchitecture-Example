using AutoMapper;
using EduZbieracz.Application.Contracts.Persistence;
using EduZbieracz.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreatedCategoryCommandHandler
        : IRequestHandler<CreatedCategoryCommand, CreatedCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public async Task<CreatedCategoryCommandResponse> Handle(CreatedCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatedCategoryCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreatedCategoryCommandResponse(validatorResult);

            var category = _mapper.Map<Category>(request);

            category = await _categoryRepository.AddAsync(category);

            return new CreatedCategoryCommandResponse(category.CategoryId);
        }

        public CreatedCategoryCommandHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
    }
}
