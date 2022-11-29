using MediatR;

namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetContractorMaterialsSearchList
{
    public class GetContractorMaterialSearchListQuery : IRequest<ContractorMaterialSearchListVm>
    {
        public string searchText { get; set; }
    }
}
