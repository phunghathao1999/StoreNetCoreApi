using ApplicationCore.EF;
using ApplicationCore.Models;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, productModels>();
            CreateMap<productModels, Product>();

            CreateMap<Cart, cartModels>();
            CreateMap<cartModels, Cart>();

            CreateMap<Cartdetail, cartdetailModels>();
            CreateMap<cartdetailModels, Cartdetail>();

            CreateMap<Promotion, promotionModels>();
            CreateMap<promotionModels, Promotion>();

            CreateMap<Account, accountModels>();
            CreateMap<accountModels, Account>();
        }
    }
}
