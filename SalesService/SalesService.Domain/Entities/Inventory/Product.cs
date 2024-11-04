using SalesService.Domain.Events.Common;
using SalesService.Domain.Entities.Common;

namespace SalesService.Domain.Entities.Inventory;

public sealed class Product : Entity
{
    private Product(Guid id)
    {
        Id = id;
    }
    
    private Product(
        string name, decimal price, 
        decimal discount, decimal finalPrice)
    {
        Id = new Guid();
        Name = name;
        Price = price;
        Discount = discount;
        FinalPrice = finalPrice;
    }

    private Product(
        Guid id, string name, decimal price,
        decimal discount, decimal finalPrice)
    {
        Id = id;
        Name = name;
        Price = price;
        Discount = discount;
        FinalPrice = finalPrice;
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public decimal Discount { get; private set; }
    public decimal FinalPrice { get; private set; }

    public static Product Create(
        string name, decimal price, 
        decimal discount, decimal finalPrice)
    {
        var product = new Product(name, price, discount, finalPrice);
        product.RaiseEvent(new ProductCreatedDomainEvent());
        return product;
    }

    public static Product Update(
        Guid id, string name, decimal price, 
        decimal discount, decimal finalPrice)
    {
        var product = new Product(id, name, price, discount, finalPrice);
        product.RaiseEvent(new ProductUpdatedDomainEvent());
        return product;
    }

    public static Product Delete(Guid id)
    {
        var product = new Product(id);
        product.RaiseEvent(new ProductDeletedDomainEvent());
        return product;
    }
}

public sealed record ProductCreatedDomainEvent() : DomainEvent;

public sealed record ProductUpdatedDomainEvent() : DomainEvent;

public sealed record ProductDeletedDomainEvent() : DomainEvent;