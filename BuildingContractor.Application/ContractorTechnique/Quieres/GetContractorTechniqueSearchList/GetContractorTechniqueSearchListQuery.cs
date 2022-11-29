using MediatR;

namespace BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueSearchList
{
    public class GetContractorTechniqueSearchListQuery : IRequest<ContractorTechniqueSearchVm>
    {
        public string searchText { get; set; }
    }
}
