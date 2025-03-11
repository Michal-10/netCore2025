using AutoMapper;
using ClubCards.Api.Models;
using ClubCards.Core.DTOs;
using ClubCardsProject.Entities;

namespace ClubCards.Api
{
    public class PostModelMappingProfile : Profile
    {
        public PostModelMappingProfile()
        {
            CreateMap<BuyingPostModel,BuyingDTO>();
            CreateMap<CardPostModel,CardDTO>();
            CreateMap<CustomerPostModel,CustomerDTO>();
            CreateMap<PurchaseCenterPostModel,PurchaseCenterDTO>();
            CreateMap<StorePostModel,StoreDTO>();
        }
    }
}
