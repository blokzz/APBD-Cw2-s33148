namespace pracaDomowa2;

public abstract class Device
{
    private static int _nextId;
    private int id;
    private string name;
    private string model;

    public Device()
    {
        id = _nextId++;
    }
    
    
    
    
}