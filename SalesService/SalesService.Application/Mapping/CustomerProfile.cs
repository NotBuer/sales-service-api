using AutoMapper;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests.Customer;
using SalesService.Domain.Entities.Customer;

namespace SalesService.Application.Mapping;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CustomerCreateMapping();
        CustomerUpdateMapping();
    }

    private void CustomerCreateMapping()
    {
        CreateMap<CreateCustomerRequest, Customer>()
            .ConstructUsing(src => Customer.Create(src.CustomerDto.Name, src.CustomerDto.Email))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.CustomerDto.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.CustomerDto.Email));
        
        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email));
    }

    private void CustomerUpdateMapping()
    {
        CreateMap<UpdateCustomerRequest, Customer>()
            .ConstructUsing(src => Customer.Update(src.Id, src.CustomerDto.Name, src.CustomerDto.Email))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.CustomerDto.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.CustomerDto.Email));

        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.Name, 
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email));
    }
}