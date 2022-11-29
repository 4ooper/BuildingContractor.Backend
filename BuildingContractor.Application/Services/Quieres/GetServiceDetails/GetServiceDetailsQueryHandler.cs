using MediatR;
using BuildingContractor.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Common.Exceptions;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Services.Quieres.GetServiceDetails
{
    public class GetServiceDetailsQueryHandler : IRequestHandler<GetServiceDetailsQuery, ServiceDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetServiceDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ServiceDetailsVm> Handle(GetServiceDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.services.Include(item => item.listOfWork).FirstOrDefaultAsync(customer => customer.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(Service), request.id);
            }

            return _mapper.Map<ServiceDetailsVm>(entity);
        }
    }
}
