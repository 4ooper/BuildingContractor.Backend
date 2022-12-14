using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Licenses.Quieres.GetLicenseList
{
    public class LicenseLookupDto : IMapWith<License>
    {
        public int id { get; set; }
        public DateTime createDate { get; set; }
        public DateTime validaty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<License, LicenseLookupDto>()
                .ForMember(recordDto => recordDto.id, opt => opt.MapFrom(record => record.id))
                .ForMember(recordDto => recordDto.createDate, opt => opt.MapFrom(record => record.createDate))
                .ForMember(recordDto => recordDto.validaty, opt => opt.MapFrom(record => record.validaty));
        }
    }
}
