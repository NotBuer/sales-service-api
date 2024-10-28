namespace SalesService.Infrastructure.Mapping._Common;

public static class SqlColumnTypeHelper
{
    public const string Int = "INT";
    
    /// <summary> Single byte size (0-255) </summary>
    public const string Tinyint = "TINYINT";
    
    /// <summary> GUID`s </summary>
    public const string UniqueIdentifier = "UNIQUEIDENTIFIER";
    
    /// <summary> Decimal type with -> Precision: 8 and Scale: 2 </summary>
    public const string DecimalP8S2 = "DECIMAL(8,2)";
    
    /// <summary> Decimal type with -> Precision: 10 and Scale: 2 </summary>
    public const string DecimalP10S2 = "DECIMAL(10,2)";
    
    /// <summary> Standard Datetime </summary>
    public const string Datetime = "DATETIME";
}