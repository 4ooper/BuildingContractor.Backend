using MediatR;

namespace BuildingContractor.Application.ListOfWorks.Commands.UpdateListOfWorks
{
    public class UpdateListOfWorkCommand : IRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public int licenseID { get; set; }
    }
}
