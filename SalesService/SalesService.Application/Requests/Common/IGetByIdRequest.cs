namespace SalesService.Application.Requests.Common;

public interface IGetByIdRequest : IRequest
{
    public Guid Id { get; set; }
}