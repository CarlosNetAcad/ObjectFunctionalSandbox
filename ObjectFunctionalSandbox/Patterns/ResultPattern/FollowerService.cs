namespace ObjectFunctionalSandbox.Patterns.ResultPattern;

public sealed class FollowerService
{
    private readonly IFollowerRepository _followerRepository;

    public FollowerService(IFollowerRepository followerRepository)
    {
        _followerRepository = followerRepository;
    }

    public async Task<Result> StartFollowingAsync(
        User user,
        User followed,
        DateTime utcNow,
        CancellationToken cancellationToken = default)
    {
        if (user.Id == followed.Id)
        {
            return Result.Failure(FollowerErrors.SameUser);
        }

        if (!followed.HasPublicProfile)
        {
            return Result.Failure(FollowerErrors.NonPublicProfile);
        }

        if (await _followerRepository.IsAlreadyFollowingAsync(
                user.Id,
                followed.Id,
                cancellationToken))
        {
            return Result.Failure(FollowerErrors.AlreadyFollowing);
        }

        var follower = Follower.Create(user.Id, followed.Id, utcNow);

        _followerRepository.Insert(follower);

        return Result.Success();
    }
}

internal class Follower
{
    internal static object Create(int id1, int id2, DateTime utcNow)
    {
        throw new NotImplementedException();
    }
}

public interface IFollowerRepository
{
    void Insert(object follower);
    Task<bool> IsAlreadyFollowingAsync(int id1, int id2, CancellationToken cancellationToken);
}

public class User
{
    public int Id { get; set; }
    public bool HasPublicProfile { get; internal set; }
}