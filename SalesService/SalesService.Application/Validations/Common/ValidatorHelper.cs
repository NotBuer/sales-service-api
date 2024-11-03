namespace SalesService.Application.Validations.Common;

public static class ValidatorHelper
{
    public static string RuleMessage_CannotBeNullOrEmpty(string objName) =>
        $"Is Required. \nObject property {objName} cannot be null or empty.";

    public static string RuleMessage_InvalidEmail() =>
        $"Valid email address is required.";
}