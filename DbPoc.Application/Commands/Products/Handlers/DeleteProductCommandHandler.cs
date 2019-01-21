using DbPoc.Domain.Entities;
using DbPoc.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DbPoc.Application.Commands.Products.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly DbPocDbContext dbPocDbContext;

        public DeleteProductCommandHandler(DbPocDbContext dbPocDbContext)
        {
            this.dbPocDbContext = dbPocDbContext;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await dbPocDbContext.Products.FindAsync(request.Id);

            dbPocDbContext.Remove(product);
            await dbPocDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
