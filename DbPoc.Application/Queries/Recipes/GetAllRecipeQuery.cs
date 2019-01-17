using DbPoc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbPoc.Application.Queries.Recipes
{
    public class GetAllRecipeQuery: IRequest<IEnumerable<Recipe>>
    {
    }
}
