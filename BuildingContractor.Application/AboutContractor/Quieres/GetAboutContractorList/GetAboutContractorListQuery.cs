using MediatR;

namespace BuildingContractor.Application.AboutContractor.Quieres.GetAboutContractorList
{
    public class GetAboutContractorListQuery : IRequest<AboutContractorVm>
    {
        public int page { get; set; }
    }
}
