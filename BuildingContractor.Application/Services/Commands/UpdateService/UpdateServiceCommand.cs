using MediatR;

namespace BuildingContractor.Application.Services.Commands.UpdateService
{
    public class UpdateServiceCommand : IRequest
    {
        public int id { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
        public int listOfWorkID { get; set; }
    }
}
