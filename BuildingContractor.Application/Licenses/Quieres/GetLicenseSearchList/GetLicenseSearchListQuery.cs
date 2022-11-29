using MediatR;

namespace BuildingContractor.Application.Licenses.Quieres.GetLicenseSearchList
{
    public class GetLicenseSearchListQuery : IRequest<LicenseSearchListVm>
    {
        public int searchText { get; set; }
    }
}
