namespace PracaDomowa2;

public interface IUserRepository
{
    void Add(User user);
    User GetById(int id);
    IEnumerable<User> GetAll();
}