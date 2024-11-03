using AutoMapper;
using SalesService.Application.DTOs.Customer.Created;
using SalesService.Application.DTOs.Customer.Updated;
using SalesService.Application.Requests.Customer;
using SalesService.Domain.Entities.Customer;

namespace SalesService.Application.Mapping;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        AddGlobalIgnore(nameof(Customer.Id));
        AddGlobalIgnore(nameof(Customer.DomainEvents));

        CustomerCreateMapping();
        CustomerUpdateMapping();
    }

    private void CustomerCreateMapping()
    {
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
    }

    private void CustomerUpdateMapping()
    {
        CreateMap<UpdateCustomerRequest, Customer>()
            .ConstructUsing(src => Customer.Create(src.UpdateCustomerDto.Name, src.UpdateCustomerDto.Email))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.UpdateCustomerDto.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.UpdateCustomerDto.Email));

        CreateMap<Customer, CustomerUpdatedDto>()
            .ForMember(dest => dest.Name, 
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email));
    }
}