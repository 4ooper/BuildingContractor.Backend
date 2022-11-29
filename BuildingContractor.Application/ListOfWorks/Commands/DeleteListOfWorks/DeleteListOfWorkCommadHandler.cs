using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ListOfWorks.Commands.DeleteListOfWorks
{
    public class DeleteListOfWorkCommadHandler : IRequestHandler<DeleteListOfWorkCommad>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteListOfWorkCommadHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteListOfWorkCommad request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.listOfWorks.FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null || entity.id != entity.id)
            {
                throw new NotFoundException(nameof(listOfWork), request.id);
            }

            _dbcontext.listOfWorks.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
