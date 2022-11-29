using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.ListOfWorks.Commands.CreateListOfWorks
{
    public class CreateListOfWorkCommandHandler : IRequestHandler<CreateListOfWorkCommand, listOfWork>
    {
        private readonly INotesDbContext _dbcontext;
        public CreateListOfWorkCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<listOfWork> Handle(CreateListOfWorkCommand request, CancellationToken cancellationToken)
        {
            var listOfWork = new listOfWork
            {
                name = request.name,
                licenseID = request.licenseID
            };

            await _dbcontext.listOfWorks.AddAsync(listOfWork, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return listOfWork;
        }
    }
}
