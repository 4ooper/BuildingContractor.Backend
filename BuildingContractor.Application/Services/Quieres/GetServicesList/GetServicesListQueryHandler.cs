using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Services.Quieres.GetServicesList
{
    public class GetServicesListQueryHandler : IRequestHandler<GetServicesListQuery, ServicesListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetServicesListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ServicesListVm> Handle(GetServicesListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.services.Skip(request.page * 15).Take(15).ProjectTo<ServiceLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.services.Count() / 15.0).ToString()));
            return new ServicesListVm
            {
                services = records,
                totalElements = _dbcontext.services.Count(),
                pagesCount = (int)pagesCount
            };
        }
    }
}
