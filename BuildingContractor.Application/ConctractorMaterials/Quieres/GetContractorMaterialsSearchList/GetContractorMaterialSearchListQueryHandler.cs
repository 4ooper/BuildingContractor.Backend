using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList;

namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetContractorMaterialsSearchList
{
    public class GetContractorMaterialSearchListQueryHandler : IRequestHandler<GetContractorMaterialSearchListQuery, ContractorMaterialSearchListVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetContractorMaterialSearchListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorMaterialSearchListVm> Handle(GetContractorMaterialSearchListQuery request, CancellationToken cancellationToken)
        {
            var records = await _dbcontext.conctractorMaterials.Where(item => item.name.Contains(request.searchText)).ProjectTo<ConctractorMaterialLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new ContractorMaterialSearchListVm
            {
                conctractorMaterials = records
            };
        }
    }
}
