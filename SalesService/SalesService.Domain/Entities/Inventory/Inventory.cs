namespace SalesService.Domain.Entities.Inventory;

public class Inventory
{
    private Inventory(int amount, DateTime updatedAt)
    {
        Amount = amount;
        UpdatedAt = updatedAt;
    }
    
    public Guid ProductId { get; private set; }
    public int Amount { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    public static Inventory Create(int amount, DateTime updatedAt) =>
        new Inventory(amount, updatedAt);
}