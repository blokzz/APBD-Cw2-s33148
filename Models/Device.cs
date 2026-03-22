namespace PracaDomowa2;

public abstract class Device
{
    private static int _nextId =1;
    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool Available { get; set; }
    public string Model { get; private set; }

    public Device(string name, string model)
    {
        Id = _nextId++;
        Name = name;
        Model = model;
        Available = true;
    }

    
    
    
    
}