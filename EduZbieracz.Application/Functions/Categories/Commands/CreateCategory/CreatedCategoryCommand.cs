using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreatedCategoryCommand : IRequest<CreatedCategoryCommandResponse>
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
}
