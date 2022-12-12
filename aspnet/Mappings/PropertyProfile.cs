using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Models;
using aspnet.dto;
using AutoMapper;

namespace aspnet.Mappings
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<Property, PropertyReadDto>();
            CreateMap<PropertyWriteDto, Property>();
            CreateMap<PropertyUpdateDto, Property>();
        }
    }
}