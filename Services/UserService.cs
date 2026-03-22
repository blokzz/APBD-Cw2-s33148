namespace PracaDomowa2;


public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public void AddUser(User user) => _repository.Add(user);

    public User GetUser(int id) => _repository.GetById(id);

    public IEnumerable<User> GetAllUsers() => _repository.GetAll();
}