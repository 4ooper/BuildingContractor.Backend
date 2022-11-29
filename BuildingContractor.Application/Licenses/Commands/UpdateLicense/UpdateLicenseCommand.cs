using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Licenses.Commands.UpdateLicense
{
    public class UpdateLicenseCommand : IRequest
    {
        public int id { get; set; }
        public DateTime createDate { get; set; }
        public DateTime validaty { get; set; }
    }
}
