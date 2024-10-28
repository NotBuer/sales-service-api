using SalesService.Domain.Entities.Common;

namespace SalesService.Domain.Entities;

public class Customer
{
    private Customer(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public static Customer Create(Guid id, string name, string email) => 
        new Customer(id, name, email);
}