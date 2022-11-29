using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Services.Commands.UpdateService;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateServiceDto : IMapWith<UpdateServiceCommand>
    {
        public int id { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
        public ListOfWorkDto listOfWork { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateServiceDto, UpdateServiceCommand>()
                .ForMember(customerCommand => customerCommand.id,
                    opt => opt.MapFrom(customerDto => customerDto.id))
                .ForMember(customerCommand => customerCommand.price,
                    opt => opt.MapFrom(customerDto => customerDto.price))
                .ForMember(customerCommand => customerCommand.discount,
                    opt => opt.MapFrom(customerDto => customerDto.discount))
                .ForMember(customerCommand => customerCommand.listOfWorkID,
                    opt => opt.MapFrom(customerDto => customerDto.listOfWork.id));
        }
    }
}
