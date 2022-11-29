using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.Licenses.Quieres.GetLicenseDetails
{
    public class LicenseDetailsVm : IMapWith<License>
    {
        public int id { get; set; }
        public DateTime createDate { get; set; }
        public DateTime validaty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<License, LicenseDetailsVm>()
                .ForMember(recordDto => recordDto.id, opt => opt.MapFrom(record => record.id))
                .ForMember(recordDto => recordDto.createDate, opt => opt.MapFrom(record => record.createDate))
                .ForMember(recordDto => recordDto.validaty, opt => opt.MapFrom(record => record.validaty));
        }
    }
}
