using MediatR;

namespace BuildingContractor.Application.Licenses.Quieres.GetLicenseList
{
    public class GetLicenseListQuery : IRequest<LicenseListVm>
    {
        public int page { get; set; }
    }
}
