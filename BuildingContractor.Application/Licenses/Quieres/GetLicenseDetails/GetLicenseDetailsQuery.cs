using MediatR;

namespace BuildingContractor.Application.Licenses.Quieres.GetLicenseDetails
{
    public class GetLicenseDetailsQuery : IRequest<LicenseDetailsVm>
    {
        public int id { get; set; }
    }
}
