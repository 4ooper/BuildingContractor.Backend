using MediatR;

namespace BuildingContractor.Application.ListOfWorks.Commands.DeleteListOfWorks
{
    public class DeleteListOfWorkCommad : IRequest
    {
        public int id { get; set; }
    }
}
