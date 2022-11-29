using MediatR;

namespace BuildingContractor.Application.Services.Commands.DeleteService
{
    public class DeleteServiceCommand : IRequest
    {
        public int id { get; set; }
    }
}
