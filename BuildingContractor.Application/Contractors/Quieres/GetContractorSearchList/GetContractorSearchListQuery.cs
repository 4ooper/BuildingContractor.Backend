using MediatR;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorSearchList
{
    public class GetContractorSearchListQuery : IRequest<ContractorSearchListVm>
    {
        public string searchText { get; set; }
    }
}
