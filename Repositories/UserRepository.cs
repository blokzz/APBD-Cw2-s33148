namespace PracaDomowa2;

public class UserRepository : IUserRepository
{
    private readonly Dictionary<int, User> _users = new();
    public void Add(User user) => _users[user.Id] = user;
    public User GetById(int id) => _users[id];
    public IEnumerable<User> GetAll() => _users.Values;
}