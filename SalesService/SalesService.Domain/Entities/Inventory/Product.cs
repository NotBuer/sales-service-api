using SalesService.Domain.Entities.Common;
using SalesService.Domain.Entities.Enums;

namespace SalesService.Domain.Entities;

public sealed class Product : Entity
{
    private Product(
        Guid id, string name, decimal price, 
        decimal discount, decimal finalPrice, ProductStatus productStatus)
    {
        Id = id;
        Name = name;
        Price = price;
        Discount = discount;
        FinalPrice = finalPrice;
        ProductStatus = productStatus;
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public decimal Discount { get; private set; }
    public decimal FinalPrice { get; private set; }
    public ProductStatus ProductStatus { get; private set; }

    public static Product Create(
        string name, decimal price, 
        decimal discount, decimal finalPrice, ProductStatus productStatus)
    {
        var product = new Product(new Guid(), name, price, discount, finalPrice, productStatus);
        product.RaiseEvent(new ProductCreatedDomainEvent());
        return product;
    }
}

public sealed record ProductCreatedDomainEvent() : DomainEvent;