using MediatR;
using AutoMapper;
using BuildingContractor.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockList;
using AutoMapper.QueryableExtensions;

namespace BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockSearchList
{
    public class GetContractorStockSearchListQueryHandler : IRequestHandler<GetContractorStockSearchListQuery, ContractorStockSearchVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbcontext;

        public GetContractorStockSearchListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<ContractorStockSearchVm> Handle(GetContractorStockSearchListQuery request, CancellationToken cancellationToken)
        {
            var stock = await _dbcontext.contractorStock.Where(item => item.conctractorMaterial.name.Contains(request.searchText)).ProjectTo<ContractorStockLookupDto>(_mapper.ConfigurationProvider).OrderBy(record => record.id).ToListAsync(cancellationToken);
            return new ContractorStockSearchVm
            {
                contractorStock = stock
            };
        }
    }
}
