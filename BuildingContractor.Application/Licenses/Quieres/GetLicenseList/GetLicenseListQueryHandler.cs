using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.Licenses.Quieres.GetLicenseList
{
    public class GetLicenseListQueryHandler : IRequestHandler<GetLicenseListQuery, LicenseListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetLicenseListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<LicenseListVm> Handle(GetLicenseListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.licenses.Skip(request.page * 15).Take(15).ProjectTo<LicenseLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.licenses.Count() / 15.0).ToString()));
            return new LicenseListVm
            {
                licenses = records,
                totalElements = _dbcontext.licenses.Count(),
                pagesCount = (int)pagesCount
            };
        }
    }
}
