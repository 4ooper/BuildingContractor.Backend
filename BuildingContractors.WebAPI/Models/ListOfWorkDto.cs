using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.WebAPI.Models
{
    public class ListOfWorkDto : IMapWith<listOfWork>
    {
        public int id { get; set; }
        public string name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<listOfWork, ListOfWorkDto>()
                .ForMember(recordDto => recordDto.id, opt => opt.MapFrom(record => record.id))
                .ForMember(recordDto => recordDto.name, opt => opt.MapFrom(record => record.name));
        }
    }
}
