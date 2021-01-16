using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduZbieracz.Application.Functions.Categories.Queries.GetCategoryList
{
    public class GetCategoriesListQuery
         : IRequest<List<CategoryInListViewModel>>
    {

    }
}
