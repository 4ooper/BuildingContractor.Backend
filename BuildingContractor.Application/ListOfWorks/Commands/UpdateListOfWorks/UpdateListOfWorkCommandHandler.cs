using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ListOfWorks.Commands.UpdateListOfWorks
{
    public class UpdateListOfWorkCommandHandler : IRequestHandler<UpdateListOfWorkCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateListOfWorkCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateListOfWorkCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.listOfWorks.FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(listOfWork), request.id);
            }

            entity.Result.name = request.name;
            entity.Result.licenseID = request.licenseID;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
