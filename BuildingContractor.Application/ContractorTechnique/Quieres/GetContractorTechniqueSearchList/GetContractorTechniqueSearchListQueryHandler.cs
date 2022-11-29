using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueList;

namespace BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueSearchList
{
    public class GetContractorTechniqueSearchListQueryHandler : IRequestHandler<GetContractorTechniqueSearchListQuery, ContractorTechniqueSearchVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetContractorTechniqueSearchListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorTechniqueSearchVm> Handle(GetContractorTechniqueSearchListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.contractorTechniques.Where(item => item.name.Contains(request.searchText)).ProjectTo<ContractorTechniqueLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.contractorTechniques.Count() / 15.0).ToString()));
            return new ContractorTechniqueSearchVm
            {
                contractorTechniques = records
            };
        }
    }
}
