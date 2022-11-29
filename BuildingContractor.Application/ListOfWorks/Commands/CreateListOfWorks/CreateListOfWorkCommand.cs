using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ListOfWorks.Commands.CreateListOfWorks
{
    public class CreateListOfWorkCommand : IRequest<listOfWork>
    {
        public string name { get; set; }
        public int licenseID { get; set; }
    }
}
