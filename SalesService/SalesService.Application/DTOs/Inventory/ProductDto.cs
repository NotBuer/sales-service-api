using SalesService.Domain.Entities.Enums;

namespace SalesService.Application.DTOs.Inventory;

public record ProductDto(
    Guid Id, string Name, decimal Price, decimal Discount, decimal FinalPrice, ProductStatus ProductStatus);