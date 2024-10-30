using SalesService.Domain.Entities.Enums;

namespace SalesService.Application.DTOs.Sale;

public record SaleDto(
    Guid Id, string CustomerName, string ProductName, DateTime SoldIn, string SoldBy, byte ProductAmount, 
    decimal ProductUnitPrice, decimal ProductUnitDiscount, decimal SaleTotalPrice, SaleStatus SaleStatus);