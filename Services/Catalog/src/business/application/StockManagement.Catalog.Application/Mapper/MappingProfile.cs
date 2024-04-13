using AutoMapper;
using StockManagement.Catalog.Domain.DTOs;
using StockManagement.Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Catalog.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, CreateProductInputDTO>().ReverseMap();
            CreateMap<ProductItem, CreateProductItemInputDTO>().ReverseMap();
        }
    }
}
