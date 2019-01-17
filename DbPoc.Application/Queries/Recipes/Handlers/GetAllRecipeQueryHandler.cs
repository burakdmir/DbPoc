using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Queries.Recipes.Handlers
{
    class GetAllRecipeQueryHandler : IRequestHandler<GetAllRecipeQuery, IEnumerable<Recipe>>
    {
        private readonly DbPocDbContext dbPocDbContext;

        public GetAllRecipeQueryHandler(DbPocDbContext dbPocDbContext)
        {
            this.dbPocDbContext = dbPocDbContext;
        }

        public async Task<IEnumerable<Recipe>> Handle(GetAllRecipeQuery request, CancellationToken cancellationToken)
        {
            return await dbPocDbContext
             .Recipes
             .AsNoTracking()
             .ToListAsync();
        }
    }
}
