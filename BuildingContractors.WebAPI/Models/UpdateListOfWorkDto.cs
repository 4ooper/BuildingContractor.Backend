using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.ListOfWorks.Commands.UpdateListOfWorks;
using BuildingContractor.Domain;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateListOfWorkDto : IMapWith<UpdateListOfWorkCommand>
    {
        public int id { get; set; }
        public string name { get; set; }
        public LicenseDto license { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateListOfWorkDto, UpdateListOfWorkCommand>()
                .ForMember(customerCommand => customerCommand.id,
                    opt => opt.MapFrom(customerDto => customerDto.id))
                .ForMember(customerCommand => customerCommand.name,
                    opt => opt.MapFrom(customerDto => customerDto.name))
                .ForMember(customerCommand => customerCommand.licenseID,
                    opt => opt.MapFrom(customerDto => customerDto.license.id));
        }
    }
}
