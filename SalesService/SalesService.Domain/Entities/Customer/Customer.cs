namespace SalesService.Domain.Entities.Customer;

public class Customer
{
    private Customer(string name, string email)
    {
        Id = new Guid();
        Name = name;
        Email = email;
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public static Customer Create(string name, string email) => 
        new Customer(name, email);
}