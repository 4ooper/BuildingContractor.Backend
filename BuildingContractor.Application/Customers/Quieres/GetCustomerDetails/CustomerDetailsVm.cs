﻿using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.Customers.Quieres.GetCustomerDetails
{
    public class CustomerDetailsVm : IMapWith<Customer>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDetailsVm>()
                .ForMember(customerVm => customerVm.id, opt => opt.MapFrom(customer => customer.id))
                .ForMember(customerVm => customerVm.name, opt => opt.MapFrom(customer => customer.name))
                .ForMember(customerVm => customerVm.surname, opt => opt.MapFrom(customer => customer.surname));
        }
    }
}
    