using AutoMapper;
using SalesService.Application.DTOs.Inventory.Product;
using SalesService.Application.Requests.Inventory.Product;
using SalesService.Domain.Entities.Customer;
using SalesService.Domain.Entities.Inventory;

namespace SalesService.Application.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        AddGlobalIgnore(nameof(Product.Id));
        AddGlobalIgnore(nameof(Product.DomainEvents));
        
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Price,
                opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Discount,
                opt => opt.MapFrom(src => src.Discount))
            .ForMember(dest => dest.FinalPrice,
                opt => opt.MapFrom(src => src.FinalPrice));
        
        ProductCreateMapping();
        ProductUpdateMapping();
        ProductDeleteMapping();
    }

    private void ProductCreateMapping()
    {
        CreateMap<CreateProductRequest, Product>()
            .ConstructUsing(src => Product.Create(src.ProductDto.Name, src.ProductDto.Price, src.ProductDto.Discount, src.ProductDto.FinalPrice))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.ProductDto.Name))
            .ForMember(dest => dest.Price,
                opt => opt.MapFrom(src => src.ProductDto.Price))
            .ForMember(dest => dest.Discount,
                opt => opt.MapFrom(src => src.ProductDto.Discount))
            .ForMember(dest => dest.FinalPrice,
                opt => opt.MapFrom(src => src.ProductDto.FinalPrice));
    }

    private void ProductUpdateMapping()
    {
        
    }

    private void ProductDeleteMapping()
    {
        
    }
}