namespace SalesService.Application.DTOs.Inventory;

public record InventoryDto(
    Guid ProductId, int Amount, DateTime UpdatedAt);