namespace pracaDomowa2;

public abstract class User
{
    private static int _nextid;
    public int Id {get; private set;}
    public string Name {get; private set;}
    public string Surname {get; private set;}
    public string Email {get; private set;}
    public string Type {get; private set;}

    public User(string name, string surname, string email, string type)
    {
        Id = ++_nextid;
        Name = name;
        Surname = surname;
        Email = email;
        Type = type;
    }
}