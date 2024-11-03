using System.Text.Json.Serialization;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.DTOs.Customer.Created;

namespace SalesService.API.JsonSerialization;

[JsonSerializable(typeof(CreateCustomerRequest))]
[JsonSerializable(typeof(CustomerCreatedResponse<>))]
[JsonSerializable(typeof(CreateCustomerDto))]
[JsonSerializable(typeof(CustomerCreatedDto))]
internal partial class CustomerJsonSerializerContext : JsonSerializerContext;