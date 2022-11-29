using MediatR;
using BuildingContractor.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Licenses.Quieres.GetLicenseDetails
{
    public class GetLicenseDetailsQueryHandler : IRequestHandler<GetLicenseDetailsQuery, LicenseDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetLicenseDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<LicenseDetailsVm> Handle(GetLicenseDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.licenses.FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(License), request.id);
            }

            return _mapper.Map<LicenseDetailsVm>(entity);
        }
    }
}
