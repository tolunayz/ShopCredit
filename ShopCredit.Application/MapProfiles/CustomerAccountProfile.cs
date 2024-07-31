using AutoMapper;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Entities;

namespace ShopCredit.Application.MapProfiles
{
    public class CustomerAccountProfile : Profile
    { 
       public CustomerAccountProfile() 
        {
            CreateMap<CustomerAccount, CustomerAccountResult>()
               .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate));
                

        }
    }
}
