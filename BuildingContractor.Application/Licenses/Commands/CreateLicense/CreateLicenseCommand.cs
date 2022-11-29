using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Licenses.Commands.CreateLicense
{
    public class CreateLicenseCommand : IRequest<License>
    {
        public DateTime createDate { get; set; }
        public DateTime validaty { get; set; }
    }
}
