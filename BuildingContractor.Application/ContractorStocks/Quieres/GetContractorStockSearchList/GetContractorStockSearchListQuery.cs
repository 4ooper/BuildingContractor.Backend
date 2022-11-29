using MediatR;

namespace BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockSearchList
{
    public class GetContractorStockSearchListQuery : IRequest<ContractorStockSearchVm>
    {
        public string searchText { get; set; }
    }
}
