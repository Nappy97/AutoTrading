namespace AutoTrading.Client.Common;

public class RestResult
{
    protected RestResult(bool success, string errorMessage)
    {
        Success = success;
        ErrorMessage = errorMessage;
    }

    public bool Success { get; }
    public string ErrorMessage { get; }

    public static RestResult AsSuccess()
    {
        return new(true, string.Empty);
    }

    public static RestResult AsFail(string errorMessage)
    {
        return new(false, errorMessage);
    }
}

public class RestResult<T> : RestResult
{
    protected RestResult(bool success, string errorMessage, T value) : base(success, errorMessage)
    {
        Value = value;
    }

    public T Value { get; }

    public static RestResult<T> AsSuccess(T value)
    {
        return new(true, string.Empty, value);
    }

    public new static RestResult<T> AsFail(string errorMessage)
    {
        return new(false, errorMessage, default!);
    }
}