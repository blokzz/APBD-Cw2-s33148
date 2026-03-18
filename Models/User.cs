namespace pracaDomowa2;

public abstract class User
{
    private static int _nextid;
    public int Id {get; private set;}
    public string Same {get; private set;}
    public string Surname {get; private set;}
    public string Email {get; private set;}
    public string Type {get; private set;}

    public User()
    {
        Id = ++_nextid;
    }
}