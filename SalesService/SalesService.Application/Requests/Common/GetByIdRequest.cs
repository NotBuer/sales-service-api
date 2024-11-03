namespace SalesService.Application.Requests.Common;

public class GetByIdRequest(Guid id) : IGetByIdRequest
{
    public Guid Id { get; set; } = id;
}