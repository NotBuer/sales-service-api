namespace SalesService.Domain.Validations;

public struct ValidationError
{
    private ValidationError(string message) => Message = message;
    
    public string Message { get; private set; }

    public static ValidationError Create(string message) => 
        new(message);
}