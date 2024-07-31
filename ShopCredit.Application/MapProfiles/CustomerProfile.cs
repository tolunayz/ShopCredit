using AutoMapper;
using ShopCredit.Application.CQRS.Results.CustomerResults;
using ShopCredit.Domain.Entities;
using ShopCredit.Entities;

namespace ShopCredit.Application.MapProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<Customer, GetCustomerQueryResult>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                   .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                   .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                   .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                   .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                   .ForMember(dest => dest.CustomerAccounts, opt => opt.MapFrom(src => src.CustomerAccounts));

            CreateMap<CustomerAccount, CustomerAccountResult>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate));
        }
    }
}
