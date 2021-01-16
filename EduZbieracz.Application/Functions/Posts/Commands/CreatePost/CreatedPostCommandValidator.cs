using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatedPostCommandValidator
        : AbstractValidator<CreatedPostCommand>
    {
        public CreatedPostCommandValidator()
        {
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
        }
    }
}
