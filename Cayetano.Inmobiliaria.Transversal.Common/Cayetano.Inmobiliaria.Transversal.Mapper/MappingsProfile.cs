using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cayetano.Inmobiliaria.Application.Dto;
using Cayetano.Inmobiliaria.Domain.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Cayetano.Inmobiliaria.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Inmuebles, InmueblesDto>().ReverseMap();
            CreateMap<Users, UsersDto>().ReverseMap();
        }
    }
}
