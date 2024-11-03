using AutoMapper;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.DTOs.Customer.Created;
using SalesService.Application.Requests;
using SalesService.Application.Responses;
using SalesService.Domain.Entities.Customer;

namespace SalesService.Application.Mapping;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        AddGlobalIgnore(nameof(Customer.DomainEvents));
        AddGlobalIgnore(nameof(Customer.Id));

        CreateMap<CreateCustomerRequest, Customer>()
            .ConstructUsing(src => Customer.Create(src.CreateCustomerDto.Name, src.CreateCustomerDto.Email))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.CreateCustomerDto.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.CreateCustomerDto.Email));
        
        CreateMap<Customer, CustomerCreatedDto>()
            .ForMember(dest=> dest.Id, 
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email));
        
        // CreateMap<Customer, CustomerCreatedDto>()
        //     .ForMember(dest => dest.Content,
        //         opt => opt.MapFrom(src => ))
    }
}