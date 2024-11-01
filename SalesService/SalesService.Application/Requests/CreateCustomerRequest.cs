using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests.Common;

namespace SalesService.Application.Requests;

public record CreateCustomerRequest(CustomerDto CustomerDto) : IAddRequest;