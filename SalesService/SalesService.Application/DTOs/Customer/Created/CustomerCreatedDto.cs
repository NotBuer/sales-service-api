namespace SalesService.Application.DTOs.Customer.Created;

public record CustomerCreatedDto(
    Guid Id, string Name, string Email);