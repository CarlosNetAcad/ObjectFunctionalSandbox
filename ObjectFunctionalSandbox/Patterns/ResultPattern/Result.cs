namespace  ObjectFunctionalSandbox.Patterns.ResultPattern;

// Call the result pattern

/*var response = (Guid userId, Guid followedId, FollowerService followerService) =>
    {
        //var result = await followerService.StartFollowingAsync(
        //    userId,
        //    followedId,
        //    DateTime.UtcNow);
        
        return result.Match(
            onSuccess: () => Results.NoContent(),
            onFailure: error => Results.BadRequest(error));
    });*/

/// <summary>
/// Result pattern
/// </summary>
public class Result
{
    private Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);

}
