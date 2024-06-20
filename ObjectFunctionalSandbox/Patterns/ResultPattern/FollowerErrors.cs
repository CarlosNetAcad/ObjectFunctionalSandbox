namespace ObjectFunctionalSandbox.Patterns.ResultPattern;
public static class FollowerErrors
{
    public static readonly Error SameUser = new Error(
        "Followers.SameUser",
        "Can't follow yourself");

    public static readonly Error NonPublicProfile = new Error(
        "Followers.NonPublicProfile",
        "Can't follow non-public profiles");

    public static readonly Error AlreadyFollowing = new Error(
        "Followers.AlreadyFollowing",
        "Already following");

    public static Error NotFound(Guid id) => new Error(
        "Followers.NotFound",
        $"The follower with Id '{id}' was not found");
}