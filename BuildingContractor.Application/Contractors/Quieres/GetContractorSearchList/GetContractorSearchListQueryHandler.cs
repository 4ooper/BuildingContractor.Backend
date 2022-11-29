using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BuildingContractor.Application.Contractors.Quieres.GetContractorList;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorSearchList
{
    public class GetContractorSearchListQueryHandler : IRequestHandler<GetContractorSearchListQuery, ContractorSearchListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetContractorSearchListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorSearchListVm> Handle(GetContractorSearchListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.contractors.Where(item => item.name.Contains(request.searchText)).ProjectTo<ContractorLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new ContractorSearchListVm
            {
                contractors = records
            };
        }
    }
}
