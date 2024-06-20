
// Call the Result Pattern

var result = ResultPattern.ReadFile( "test.text" );

if( result.IsSuccess )
    Console.WriteLine( result.Value );
else
    Console.WriteLine( result.Error );


/// <summary>
/// Result pattern with generics.
/// </summary>
/// <typeparam name="T"></typeparam>
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

/// <summary>
/// Class used to test Result<T>
/// </summary>
public static class ResultPattern
{
    public static Result<int> Divide( int numerator, int denominator )
    {
        if( denominator == 0 )
            return Result<int>.Failure( "Denominator must be higher than zero");

        return Result<int>.Success( numerator / denominator );
    }

    public static Result<string> ReadFile( string path )
    {
        if ( string.IsNullOrWhiteSpace( path ) )
            return Result<string>.Failure( "The file path is Empty." );

        if( !File.Exists( path ) )
            return Result<string>.Failure( "File not found" );

        string textContent = File.ReadAllText( path );

        return Result<string>.Success( textContent );

    }

}

