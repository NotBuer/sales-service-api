using AutoMapper;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests.Customer;
using SalesService.Domain.Entities.Customer;

namespace SalesService.Application.Mapping;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        AddGlobalIgnore(nameof(Customer.Id));
        AddGlobalIgnore(nameof(Customer.DomainEvents));
        
        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email));
        
        CustomerCreateMapping();
        CustomerUpdateMapping();
        CustomerDeleteMapping();
    }

    private void CustomerCreateMapping()
    {
        CreateMap<CreateCustomerRequest, Customer>()
            .ConstructUsing(src => Customer.Create(src.CustomerDto.Name, src.CustomerDto.Email))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.CustomerDto.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.CustomerDto.Email));
    }

    private void CustomerUpdateMapping()
    {
        CreateMap<UpdateCustomerRequest, Customer>()
            .ConstructUsing(src => Customer.Update(src.Id, src.CustomerDto.Name, src.CustomerDto.Email))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.CustomerDto.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.CustomerDto.Email));
    }

    private void CustomerDeleteMapping()
    {
        CreateMap<DeleteCustomerRequest, Customer>()
            .ConstructUsing(src => Customer.Delete(src.Id))
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.Ignore())
            .ForMember(dest => dest.Email, opt => opt.Ignore());
    }
}