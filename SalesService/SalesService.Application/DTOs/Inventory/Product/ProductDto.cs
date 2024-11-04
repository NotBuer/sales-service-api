using SalesService.Domain.Entities.Enums;

namespace SalesService.Application.DTOs.Inventory.Product;

public record ProductDto(
    string Name, decimal Price, decimal Discount, decimal FinalPrice);