using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BuildingContractor.Application.Licenses.Quieres.GetLicenseList;

namespace BuildingContractor.Application.Licenses.Quieres.GetLicenseSearchList
{
    public class GetLicenseSearchListQueryHandler : IRequestHandler<GetLicenseSearchListQuery, LicenseSearchListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetLicenseSearchListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<LicenseSearchListVm> Handle(GetLicenseSearchListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.licenses.Where(item => item.id == request.searchText).ProjectTo<LicenseLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new LicenseSearchListVm
            {
                licenses = records
            };
        }
    }
}
