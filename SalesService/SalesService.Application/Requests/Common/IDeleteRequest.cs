namespace SalesService.Application.Requests.Common;

public interface IDeleteRequest : IRequest
{
    public Guid Id { get; set; }
}