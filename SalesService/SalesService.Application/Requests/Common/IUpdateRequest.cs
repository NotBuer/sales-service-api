namespace SalesService.Application.Requests.Common;

public interface IUpdateRequest : IRequest
{
    public Guid Id { get; set; }
}