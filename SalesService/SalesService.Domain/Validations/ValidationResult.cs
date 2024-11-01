namespace SalesService.Domain.Validations;

public class ValidationResult
{
    public enum ValidationErrorCode : ushort
    {
        Unauthorized = 401,
        NotFound = 404,
        Conflict = 409,
        UnprocessableEntity = 422,
    }
    
    public ValidationErrorCode ErrorCode { get; private set; }
    private List<ValidationError> _validationErrorsList;
    public bool IsValid => _validationErrorsList.Count == 0;

    public ValidationResult()
    {
        _validationErrorsList = [];
    }

    public ValidationResult Add(string errorMessage, ValidationErrorCode errorCode)
    {
        _validationErrorsList.Add(ValidationError.Create(errorMessage));
        ErrorCode = errorCode;
        return this;
    }

    public ValidationResult Add(params ValidationResult[] validationResults)
    { 
        foreach (var result in validationResults) 
            _validationErrorsList.AddRange(result._validationErrorsList);
        
        return this;
    }

    public void AddFluentValidationResult(FluentValidation.Results.ValidationResult validationResult)
    {
        if (validationResult.IsValid) return;

        ErrorCode = ValidationErrorCode.UnprocessableEntity;
        _validationErrorsList.AddRange(
            validationResult.Errors.Select(
                x => ValidationError.Create(
                    $"$Message: {x.ErrorMessage} \n Property: {x.PropertyName} \n AttemptedValue: {x.AttemptedValue}")));
    }
    
}