using MediatR;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Licenses.Commands.UpdateLicense
{
    public class UpdateLicenseCommandHandler : IRequestHandler<UpdateLicenseCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public UpdateLicenseCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateLicenseCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.licenses.FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(License), request.id);
            }

            entity.Result.createDate = request.createDate;
            entity.Result.validaty = request.validaty;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
