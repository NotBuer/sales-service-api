

using System.Text.Json.Serialization;
using SalesService.Application.DTOs.Customer;
using SalesService.Application.Requests;
using SalesService.Application.Responses;

namespace SalesService.API.JsonSerialization;

[JsonSerializable(typeof(CreateCustomerRequest))]
[JsonSerializable(typeof(CustomerCreatedResponse))]
[JsonSerializable(typeof(CustomerDto))]
internal partial class CustomerJsonSerializerContext : JsonSerializerContext;