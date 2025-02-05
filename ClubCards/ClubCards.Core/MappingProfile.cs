using AutoMapper;
using ClubCards.Core.DTOs;
using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BuyingEntity, BuyingDTO>().ReverseMap();
            CreateMap<CardEntity, CardDTO>().ReverseMap();
            CreateMap<CustomerEntity, CustomerDTO>().ReverseMap();
            CreateMap<PurchaseCenterEntity, PurchaseCenterDTO>().ReverseMap();
            CreateMap<StoreEntity, StoreDTO>().ReverseMap();
        }
    }
}
