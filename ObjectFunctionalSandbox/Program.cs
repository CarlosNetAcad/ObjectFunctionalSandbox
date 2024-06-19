Result<int> Divide( int numerator, int denominator )
{
    if( denominator == 0 )
        return Result<int>.Failure( "Denominator must be higher than zero");

    return Result<int>.Success( numerator / denominator );
}

public class Result<T>
{
    /// <summary>
    /// Value prop.
    /// </summary>
    /// <value></value>
    public T Value { get; set; }

    /// <summary>
    /// IsSuccess prop.
    /// </summary>
    /// <value></value>
    public bool IsSuccess { get; }

    /// <summary>
    /// Error prop.
    /// </summary>
    /// <value></value>
    public string? Error { get; }

    private Result(T value, bool isSuccess, string? error)
    {
        Value = value;
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result<T> Success(T value) => new Result<T>( value, true, null);

    public static Result<T> Failure( string error) => new Result<T>( default, false, error);


}

