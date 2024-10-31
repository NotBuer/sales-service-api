namespace SalesService.Domain.Interfaces.Service;

public interface IService<TEntity> : IWriteService<TEntity>
    where TEntity : class
{
    
}