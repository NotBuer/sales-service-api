using SalesService.Domain.Entities.Common;
using SalesService.Domain.Events.Common;

namespace SalesService.Domain.Entities.Customer;

public class Customer : Entity
{
    private Customer(string name, string email)
    {
        Id = new Guid();
        Name = name;
        Email = email;
    }
    
    private Customer(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public static Customer Create(string name, string email)
    {
        var customer = new Customer(name, email);
        customer.RaiseEvent(new CustomerCreatedDomainEvent());
        return customer;
    }

    public static Customer Update(Guid id, string name, string email)
    {
        var customer = new Customer(id, name, email);
        customer.RaiseEvent(new CustomerUpdatedDomainEvent());
        return customer;
    }
    
    public static void Delete(Customer customer) =>
        customer.RaiseEvent(new CustomerDeletedDomainEvent());
        
}

public sealed record CustomerCreatedDomainEvent() : DomainEvent; 

public sealed record CustomerUpdatedDomainEvent() : DomainEvent;

public sealed record CustomerDeletedDomainEvent() : DomainEvent; 