using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.Services.Commands.CreateService
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Service>
    {
        private readonly INotesDbContext _dbcontext;

        public CreateServiceCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Service> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Service
            {
                price = request.price,
                discount = request.discount,
                listOfWorkID = request.listOfWorkID
            };

            await _dbcontext.services.AddAsync(service, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return service;
        }
    }
}
