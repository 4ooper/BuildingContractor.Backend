using MediatR;
using BuildingContractor.Domain;
using BuildingContractor.Application.Interfaces;

namespace BuildingContractor.Application.Licenses.Commands.CreateLicense
{
    public class CreateLicenseCommandHandler : IRequestHandler<CreateLicenseCommand, License>
    {
        private readonly INotesDbContext _dbcontext;
        public CreateLicenseCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<License> Handle(CreateLicenseCommand request, CancellationToken cancellationToken)
        {
            var license = new License
            {
                createDate = request.createDate,
                validaty = request.validaty
            };

            await _dbcontext.licenses.AddAsync(license, cancellationToken).AsTask();
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return license;
        }
    }
}
