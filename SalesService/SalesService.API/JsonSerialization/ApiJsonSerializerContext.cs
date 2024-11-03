using System.Text.Json.Serialization;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.DTOs.Customer.Created;
using SalesService.Application.DTOs.Customer.Updated;
using SalesService.Application.Requests.Customer;
using SalesService.Application.Responses.Customer;

namespace SalesService.API.JsonSerialization;

[JsonSerializable(typeof(CreateCustomerRequest))]
[JsonSerializable(typeof(CustomerCreatedResponse<>))]
[JsonSerializable(typeof(CreateCustomerDto))]
[JsonSerializable(typeof(CustomerCreatedDto))]
[JsonSerializable(typeof(UpdateCustomerRequest))]
[JsonSerializable(typeof(CustomerUpdatedResponse<>))]
[JsonSerializable(typeof(UpdateCustomerDto))]
[JsonSerializable(typeof(CustomerUpdatedDto))]
internal partial class CustomerJsonSerializerContext : JsonSerializerContext;