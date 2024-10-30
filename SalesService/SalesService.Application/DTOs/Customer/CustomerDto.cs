namespace SalesService.Application.DTOs.Customer;

public record CustomerDto(
    Guid Id, string Name, string Email);