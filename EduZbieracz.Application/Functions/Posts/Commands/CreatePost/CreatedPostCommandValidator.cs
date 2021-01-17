using EduZbieracz.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EduZbieracz.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatedPostCommandValidator
        : AbstractValidator<CreatedPostCommand>
    {
        private readonly IPostRepository _postRepository;

        public CreatedPostCommandValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;

            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(80)
                .WithMessage("{PropertyName} must not exceed 80 characters");

            RuleFor(p => p.Date)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .LessThan(DateTime.Now.AddDays(1));

            RuleFor(p => p.Rate)
                .InclusiveBetween(0, 100)
                .WithMessage("{PropertyName} is beetween 0 to 100");

            RuleFor(p => p).
                MustAsync(IsNameAndAuthorAlreadyExist)
                .WithMessage("Post with the same Title and Author already exist");
        }


        private async Task<bool> IsNameAndAuthorAlreadyExist
            (CreatedPostCommand e, CancellationToken cancellationToken)
        {
            var check = await _postRepository.
                IsNameAndAuthorAlreadyExist(e.Title, e.Author);
            return !check;
        }
    }
}
