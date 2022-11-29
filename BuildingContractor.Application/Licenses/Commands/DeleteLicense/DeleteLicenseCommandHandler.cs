using MediatR;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Licenses.Commands.DeleteLicense
{
    public class DeleteLicenseCommandHandler : IRequestHandler<DeleteLicenseCommand>
    {
        private readonly INotesDbContext _dbcontext;
        public DeleteLicenseCommandHandler(INotesDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteLicenseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.licenses.FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null || entity.id != entity.id)
            {
                throw new NotFoundException(nameof(License), request.id);
            }

            _dbcontext.licenses.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
