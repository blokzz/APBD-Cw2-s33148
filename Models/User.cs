namespace PracaDomowa2;

public abstract class User
{
    private static int _nextid;
    public int Id {get; private set;}
    public string Name {get; private set;}
    public string Surname {get; private set;}
    public string Email {get; private set;}
    public abstract int MaxRentals {get;}

    protected User(string name, string surname, string email)
    {
        Id = ++_nextid;
        Name = name;
        Surname = surname;
        Email = email;
    }
}