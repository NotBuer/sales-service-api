using SalesService.Domain.Events.Common;
using SalesService.Domain.Entities.Common;
using SalesService.Domain.Entities.Enums;

namespace SalesService.Domain.Entities.Sale;

public sealed class Sale : Entity
{
    private Sale(
        string customerName, string productName,  DateTime soldIn,  string soldBy,  byte productAmount,
        decimal productUnitPrice,  decimal productUnitDiscount,  decimal saleTotalPrice,  SaleStatus saleStatus)
    {
        Id = new Guid();
        CustomerName = customerName;
        ProductName = productName;
        SoldIn = soldIn;
        SoldBy = soldBy;
        ProductAmount = productAmount;
        ProductUnitPrice = productUnitPrice;
        ProductUnitDiscount = productUnitDiscount;
        SaleTotalPrice = saleTotalPrice;
        SaleStatus = saleStatus;
    }

    public Guid Id { get; private set; }
    public string CustomerName { get; private set; }
    public string ProductName { get; private set; }
    public DateTime SoldIn { get; private set; }
    public string SoldBy { get; private set; }
    public byte ProductAmount { get; private set; }
    public decimal ProductUnitPrice { get; private set; }
    public decimal ProductUnitDiscount { get; private set; }
    public decimal SaleTotalPrice { get; private set; }
    public SaleStatus SaleStatus { get; private set; }
    
    public static Sale Create(
        string customerName, string productName,  DateTime soldIn,  string soldBy,  byte productAmount,
        decimal productUnitPrice,  decimal productUnitDiscount,  decimal saleTotalPrice,  SaleStatus saleStatus)
    {
        var sale = new Sale(
            customerName, productName, soldIn, soldBy, productAmount, 
            productUnitPrice, productUnitDiscount, saleTotalPrice, saleStatus
        );
        sale.RaiseEvent(new SaleCreatedDomainEvent());
        return sale;
    }
    
    // TODO: Validate sale change behavior later on. 
    public static void Change(Sale sale) =>
        sale.RaiseEvent(new SaleChangedDomainEvent());

    // TODO: Validate sale cancel behavior later on.
    public static void Cancel(Sale sale) =>
        sale.RaiseEvent(new SaleCanceledDomainEvent());
}

public sealed record SaleCreatedDomainEvent() : DomainEvent;
public sealed record SaleChangedDomainEvent() : DomainEvent;
public sealed record SaleCanceledDomainEvent() : DomainEvent;