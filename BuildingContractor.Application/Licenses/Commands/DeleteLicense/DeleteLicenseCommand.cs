using MediatR;

namespace BuildingContractor.Application.Licenses.Commands.DeleteLicense
{
    public class DeleteLicenseCommand : IRequest
    {
        public int id { get; set; }
    }
}
