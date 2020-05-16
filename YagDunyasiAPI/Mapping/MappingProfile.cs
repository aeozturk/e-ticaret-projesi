using AutoMapper;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YagDunyasiAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductAddDto, Product>();
            CreateMap<OrderAddDto, Order>();

            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.ProductName, opt =>
                { opt.MapFrom(src => src.ProductName); })
                .ForMember(dest => dest.Price, opt =>
                { opt.MapFrom(src => src.Price); })
                .ForMember(dest => dest.Liter, opt =>
                { opt.MapFrom(src => src.Liter); })
                .ForMember(dest => dest.Viskozite, opt =>
                { opt.MapFrom(src => src.Viskozite); });

        }
    }
}
