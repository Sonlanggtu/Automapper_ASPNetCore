using AutoMapper;
using FluentValidationASPNET.Domain;
using FluentValidationASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationASPNET.Mapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
            //CreateMap<List<CustomerViewModel>, List<Customer>>();
        }
    }
}
