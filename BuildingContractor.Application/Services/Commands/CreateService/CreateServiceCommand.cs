using MediatR;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Services.Commands.CreateService
{
    public class CreateServiceCommand : IRequest<Service>
    {
        public int price { get; set; }
        public int discount { get; set; }
        public int listOfWorkID { get; set; }
    }
}
