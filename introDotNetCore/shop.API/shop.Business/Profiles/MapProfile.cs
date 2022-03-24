using AutoMapper;
using shop.DTOs.Requests;
using shop.DTOs.Responses;
using shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Business.Profiles
{
   public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductListDisplayResponse>().ReverseMap();
            //.ForMember(dest=>dest.Price, src=>src.MapFrom(x=>x.Price*(1-x.Discount)));
            CreateMap<AddProductRequest, Product>();
        }
    }
}
