using System.Text.Json.Serialization;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests.Customer;
using SalesService.Application.Responses.Customer;

namespace SalesService.API.JsonSerialization;

[JsonSerializable(typeof(CreateCustomerRequest))]
[JsonSerializable(typeof(CustomerCreatedResponse<>))]
[JsonSerializable(typeof(UpdateCustomerRequest))]
[JsonSerializable(typeof(CustomerUpdatedResponse<>))]
[JsonSerializable(typeof(CustomerDto))]
internal partial class CustomerJsonSerializerContext : JsonSerializerContext;