using SalesService.Domain.Validations;

namespace SalesService.API.Validations;

internal static class Result
{
    // internal static IResult From(object? result, ValidationResult validationResult)
    // {
    //     if (validationResult.IsValid) return Results.Ok(result);
    //     if (result == null) return Results.NotFound();
    //
    //     return From(validationResult);
    // }
    
    internal static IResult From(object? result, ValidationResult validationResult)
    {
        if (validationResult.IsValid) return Results.Ok(result);
        if (result == null) return Results.NotFound();

        return From(validationResult);
    }

    internal static IResult From(ValidationResult validationResult)
    {
        if (validationResult.IsValid) return Results.Ok();
        return validationResult.ErrorCode switch
        {
            ValidationResult.ValidationErrorCode.Unauthorized => Results.Unauthorized(),
            ValidationResult.ValidationErrorCode.NotFound => Results.NotFound(),
            ValidationResult.ValidationErrorCode.Conflict => Results.Conflict(),
            ValidationResult.ValidationErrorCode.UnprocessableEntity => Results.UnprocessableEntity(),
            _ => Results.BadRequest(validationResult)
        };
    }
}