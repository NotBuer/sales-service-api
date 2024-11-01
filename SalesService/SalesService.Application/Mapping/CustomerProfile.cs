using AutoMapper;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests;
using SalesService.Domain.Entities.Customer;

namespace SalesService.Application.Mapping;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CreateCustomerRequest, Customer>()
            .ConstructUsing(src => Customer.Create(src.CustomerDto.Name, src.CustomerDto.Email))
            .ForMember(dest => dest.Id, 
                opt => opt.MapFrom(src => src.CustomerDto.Id))
            .ForMember(dest => dest.Name, 
                opt => opt.MapFrom(src => src.CustomerDto.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.CustomerDto.Email));
    }
}