namespace Primitives;

/// <summary>
///     Общие ошибки
/// </summary>
public static class GeneralErrors
{
    public static Error ValueIsInvalid(string parameterName)
    {
        if (string.IsNullOrEmpty(parameterName)) 
            throw new ArgumentException(parameterName);

        return new Error("value.is.invalid", $"Value is invalid for {parameterName}");
    }

    public static Error ValueIsRequired(string parameterName)
    {
        if (string.IsNullOrEmpty(parameterName)) 
            throw new ArgumentException(parameterName);

        return new Error("value.is.required", $"Value is required for {parameterName}");
    }
}