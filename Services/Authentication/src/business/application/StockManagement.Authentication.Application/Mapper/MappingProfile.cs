using AutoMapper;
using StockManagement.User.Domain.DTOs;
using StockManagement.User.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.User.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserAppDTO, UserApp>().ReverseMap();
        }
    }
}
